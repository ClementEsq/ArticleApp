using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.Infrastructure.Interfaces;
using ArticleApi.Service.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ArticleApi.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/article")]
    public class ArticleController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<GenericResponse<IEnumerable<Article>>> GetAllArticles()
        {
            return await _articleService.GetAllArticles();
        }

        [HttpPost]
        [Route("publish")]
        public async Task<ActionResult<HttpStatusCode>> PublishArticle([FromBody]ArticleRequest ar)
        {

            var statusCode = await _articleService.PublishArticle(ar);

            return statusCode;
        }

        [HttpDelete]
        [Route("delete/{articleId}")]
        public async Task<ActionResult<HttpStatusCode>> DeleteArticle(int articleId)
        {

            var statusCode = await _articleService.DeleteArticle(articleId);

            return statusCode;
        }

        [HttpGet]
        [Route("{articleId}")]
        public async Task<ActionResult<GenericResponse<Article>>> GetArticle(int articleId)
        {

            var article = await _articleService.GetArticle(articleId);

            return article;
        }

        [HttpGet]
        [Route("likes/{articleId}")]
        public async Task<ActionResult<GenericResponse<IEnumerable<ArticleLike>>>> GetArticleLikes(int articleId)
        {

            var articleLike = await _articleService.GetArticleLikes(articleId);

            return articleLike;
        }

        [HttpPost]
        [Route("like/{articleId}/{userId}")]
        public async Task<ActionResult<HttpStatusCode>> LikeArticle(int articleId, int userId)
        {

            var statusCode = await _articleService.LikeArticle(articleId, userId);

            return statusCode;
        }
    }
}
