using ArticleApi.Service.Infrastructure.Interfaces;
using System;
using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using System.Threading.Tasks;
using ArticleApi.Service.DAL.Interfaces;
using System.Net;
using ArticleApi.Service.Models;
using ArticleApi.Service.DTO.Helpers;
using System.Collections.Generic;

namespace ArticleApi.Service.Infrastructure
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<HttpStatusCode> DeleteArticle(int articleId)
        {
            var responseCode = HttpStatusCode.OK;

            try
            {
                await _articleRepository.Delete(new Article() { ArticleId = articleId });
            }
            catch (Exception ex)
            {
                responseCode = HttpStatusCode.InternalServerError;
            }

            return responseCode;
        }

        public async Task<HttpStatusCode> PublishArticle(ArticleRequest article)
        {
            var responseCode = HttpStatusCode.OK;

            try
            {
                var articleObj = DTOConverterHelper.CreateArticleObjectFromRequest(article);
                await _articleRepository.Save(articleObj);
            }
            catch (Exception ex)
            {
                responseCode = HttpStatusCode.InternalServerError;
            }

            return responseCode;
        }

        public async Task<GenericResponse<IEnumerable<Article>>> GetAllArticles()
        {
            var response = new GenericResponse<IEnumerable<Article>>();

            try
            {
                response.Status = HttpStatusCode.OK;
                response.Message = "Success";

                var articles = await _articleRepository.GetAllArticles();

                response.Payload = articles;
            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
            }

            return response;
        }

        public async Task<GenericResponse<Article>> GetArticle(int articleId)
        {
            var response = new GenericResponse<Article>();

            try
            {
                response.Status = HttpStatusCode.OK;
                response.Message = "Success";

                var article = await _articleRepository.Get(articleId);

                response.Payload = article;
            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
            }

            return response;
        }

        public async Task<GenericResponse<IEnumerable<ArticleLike>>> GetArticleLikes(int articleId)
        {
            var response = new GenericResponse<IEnumerable<ArticleLike>>();

            try
            {
                response.Status = HttpStatusCode.OK;
                response.Message = "Success";

                var article = await _articleRepository.GetAllArticleLikes(articleId);

                response.Payload = article;
            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
            }

            return response;
        }

        public async Task<HttpStatusCode> LikeArticle(int articleId, int userId)
        {
            var responseCode = HttpStatusCode.OK;

            try
            {

                await _articleRepository.AddArticleLike(articleId, userId);

            }
            catch (Exception ex)
            {
                responseCode = HttpStatusCode.InternalServerError;
            }

            return responseCode;
        }
    }
}
