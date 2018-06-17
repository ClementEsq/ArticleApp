using ArticleApi.Service.DAL.Interfaces;
using System;
using System.Collections.Generic;
using ArticleApi.Service.Models;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace ArticleApi.Service.DAL
{
    public class ArticleRepository : IArticleRepository, IArticleLikeRepository
    {
        private readonly IArticleRepositoryConnection _ArticleRepositoryConnection;

        public ArticleRepository(IArticleRepositoryConnection ArticleRepositoryConnection)
        {
            _ArticleRepositoryConnection = ArticleRepositoryConnection;
        }

        public async Task Delete(Article entity)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", entity.ArticleId);

                var returnValue = await _ArticleRepositoryConnection.Connection.QueryFirstAsync<int>("DeleteArticle", parameter, commandType: CommandType.StoredProcedure);

                if (returnValue != 0)
                {
                    throw new Exception("Unable to delete article.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Article> Get(int id)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", id);

                var article = await _ArticleRepositoryConnection.Connection.QueryFirstOrDefaultAsync<Article>("GetArticle", parameter, commandType: CommandType.StoredProcedure);

                return article;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            try
            {
                var articles = await _ArticleRepositoryConnection.Connection.QueryAsync<Article>("GetAllArticles", commandType: CommandType.StoredProcedure);

                return articles;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Save(Article entity)
        {
            try
            {
                var returnValue = entity.ArticleId == null ? await CreateNewArticle(entity) : await UpdateExistingArticle(entity);

                if (returnValue != 0)
                {
                    throw new Exception("Unable to save article.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ArticleLike>> GetAllArticleLikes(int articleId)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", articleId);

                var articleLikes = await _ArticleRepositoryConnection.Connection.QueryAsync<ArticleLike>("GetAllArticleLikes", parameter, commandType: CommandType.StoredProcedure);

                return articleLikes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddArticleLike(int articleId, int userId)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", articleId);
                parameter.Add("@UserId", userId);

                var returnValue = await _ArticleRepositoryConnection.Connection.QueryFirstAsync<int>("AddArticleLike", parameter, commandType: CommandType.StoredProcedure);

                if (returnValue != 0)
                {
                    throw new Exception("Unable to add article like.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveArticleLike(int articleId, int userId)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", articleId);
                parameter.Add("@UserId", userId);

                var returnValue = await _ArticleRepositoryConnection.Connection.QueryFirstAsync<int>("RemoveArticleLike", parameter, commandType: CommandType.StoredProcedure);

                if (returnValue != 0)
                {
                    throw new Exception("Unable to remove article like.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<int> CreateNewArticle(Article entity)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ArticleTitle", entity.Title);
            parameter.Add("@ArticleBody", entity.Body);
            parameter.Add("@IsPublished", entity.IsPublished);
            parameter.Add("@ArticleHeroImagePath", entity.HeroImagePath);
            parameter.Add("@ArticleBodyImagePath", entity.BodyImagePath);
            parameter.Add("@ArticleAuthorId", entity.User.UserId);

            return await _ArticleRepositoryConnection.Connection.QueryFirstAsync<int>("CreateArticle", parameter, commandType: CommandType.StoredProcedure);
        }

        private async Task<int> UpdateExistingArticle(Article entity)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ArticleId", entity.ArticleId);
            parameter.Add("@ArticleTitle", entity.Title);
            parameter.Add("@ArticleBody", entity.Body);
            parameter.Add("@IsPublished", entity.IsPublished);
            parameter.Add("@ArticleHeroImagePath", entity.HeroImagePath);
            parameter.Add("@ArticleBodyImagePath", entity.BodyImagePath);

            return await _ArticleRepositoryConnection.Connection.QueryFirstAsync<int>("UpdateArticle", parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
