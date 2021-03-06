﻿using ArticleApi.Service.DAL.Interfaces;
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
            try
            {
                _dalSession.UnitOfWork.Begin();

                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", entity.ArticleId);

                var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("DeleteArticle", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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
        public async Task<Article> Get(int id)
        {

            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", id);

                var article = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstOrDefaultAsync<Article>("GetArticle", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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
                var articles = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryAsync<Article>("GetAllArticles", transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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

        public async Task<IEnumerable<ArticleLike>> GetAllArticleLikes(int articleId)
        {
            try
            {

                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", articleId);

                var articleLikes = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryAsync<ArticleLike>("GetAllArticleLikes", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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
                _dalSession.UnitOfWork.Begin();

                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", articleId);
                parameter.Add("@UserId", userId);

                var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("AddArticleLike", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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

        public async Task RemoveArticleLike(int articleId, int userId)
        {
            try
            {
                _dalSession.UnitOfWork.Begin();

                var parameter = new DynamicParameters();
                parameter.Add("@ArticleId", articleId);
                parameter.Add("@UserId", userId);

                var returnValue = await _dalSession.UnitOfWork.RepositoryConnection.Connection.QueryFirstAsync<int>("RemoveArticleLike", parameter, transaction: _dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);

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

        private async Task<int> CreateNewArticle(Article entity, IDalSession dalSession)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@ArticleTitle", entity.Title);
            parameter.Add("@ArticleBody", entity.Body);
            parameter.Add("@IsPublished", entity.IsPublished);
            parameter.Add("@ArticleHeroImagePath", entity.HeroImagePath);
            parameter.Add("@ArticleBodyImagePath", entity.BodyImagePath);
            parameter.Add("@ArticleAuthorId", entity.User.UserId);

            return await dalSession.UnitOfWork.RepositoryConnection.Connection.ExecuteScalarAsync<int>("CreateArticle", parameter, transaction: dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);
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

            return await dalSession.UnitOfWork.RepositoryConnection.Connection.ExecuteScalarAsync<int>("UpdateArticle", parameter, transaction: dalSession.UnitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            _dalSession.Dispose();
        }
    }
}
