using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface IArticleService
    {
        Task<HttpStatusCode> PublishArticle(ArticleRequest article);
        Task<HttpStatusCode> DeleteArticle(int articleId);
        Task<GenericResponse<IEnumerable<Article>>> GetAllArticles();
        Task<GenericResponse<Article>> GetArticle(int articleId);
        Task<HttpStatusCode> LikeArticle(int articleId, int userId);
        Task<GenericResponse<IEnumerable<ArticleLike>>> GetArticleLikes(int articleId);
    }
}