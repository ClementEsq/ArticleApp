using ArticleApi.Service.DAL.Interfaces;
using System;
using System.Collections.Generic;
using ArticleApi.Service.Models;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ArticleApi.Service.DAL
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IDalSession _dalSession;

        public ArticleRepository(IDalSession dalSession)
        {
            _dalSession = dalSession;
        }

        public async Task Delete(Article entity)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@ArticleId", entity.ArticleId);

                    var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("DeleteArticle", parameter, commandType: CommandType.StoredProcedure);

                    if (returnValue != 0)
                    {
                        throw new Exception("Unable to delete article.");
                    }

                    _dalSession.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }
        public async Task<Article> Get(int id)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@ArticleId", id);

                    var article = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstOrDefaultAsync<Article>("GetArticle", parameter, commandType: CommandType.StoredProcedure);

                    _dalSession.UnitOfWork.Commit();

                    return article;
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var articles = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryAsync<Article>("GetAllArticles", commandType: CommandType.StoredProcedure);

                    _dalSession.UnitOfWork.Commit();

                    return articles;
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task Save(Article entity)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var returnValue = entity.ArticleId == null ? await CreateNewArticle(entity, _dalSession) : await UpdateExistingArticle(entity, _dalSession);

                    if (returnValue != 0)
                    {
                        throw new Exception("Unable to save article.");
                    }

                    _dalSession.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<IEnumerable<ArticleLike>> GetAllArticleLikes(int articleId)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@ArticleId", articleId);

                    var articleLikes = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryAsync<ArticleLike>("GetAllArticleLikes", parameter, commandType: CommandType.StoredProcedure);

                    _dalSession.UnitOfWork.Commit();

                    return articleLikes;
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task AddArticleLike(int articleId, int userId)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@ArticleId", articleId);
                    parameter.Add("@UserId", userId);

                    var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("AddArticleLike", parameter, commandType: CommandType.StoredProcedure);

                    if (returnValue != 0)
                    {
                        throw new Exception("Unable to add article like.");
                    }

                    _dalSession.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        public async Task RemoveArticleLike(int articleId, int userId)
        {
            using (_dalSession)
            {
                try
                {
                    _dalSession.UnitOfWork.Begin();

                    var parameter = new DynamicParameters();
                    parameter.Add("@ArticleId", articleId);
                    parameter.Add("@UserId", userId);

                    var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("RemoveArticleLike", parameter, commandType: CommandType.StoredProcedure);

                    if (returnValue != 0)
                    {
                        throw new Exception("Unable to remove article like.");
                    }

                    _dalSession.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _dalSession.UnitOfWork.Rollback();
                    throw ex;
                }
            }
        }

        private async Task<int> CreateNewArticle(Article entity, IDalSession dalSession)
        {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleTitle", entity.Title);
                parameter.Add("@ArticleBody", entity.Body);
                parameter.Add("@IsPublished", entity.IsPublished);
                parameter.Add("@ArticleHeroImagePath", entity.HeroImagePath);
                parameter.Add("@ArticleBodyImagePath", entity.BodyImagePath);
                parameter.Add("@ArticleAuthorId", entity.User.UserId);

                return await dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("CreateArticle", parameter, commandType: CommandType.StoredProcedure);
        }

        private async Task<int> UpdateExistingArticle(Article entity, IDalSession dalSession)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ArticleId", entity.ArticleId);
            parameter.Add("@ArticleTitle", entity.Title);
            parameter.Add("@ArticleBody", entity.Body);
            parameter.Add("@IsPublished", entity.IsPublished);
            parameter.Add("@ArticleHeroImagePath", entity.HeroImagePath);
            parameter.Add("@ArticleBodyImagePath", entity.BodyImagePath);

            return await dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("UpdateArticle", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
