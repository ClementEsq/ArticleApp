using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using System.Net;
using System.Threading.Tasks;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface IArticleService
    {
        Task<HttpStatusCode> PublishArticle(ArticleRequest article);
        Task<HttpStatusCode> DeleteArticle(int articleId);
        Task<GenericResponse<object>> GetAllArticles();
        Task<GenericResponse<object>> GetArticle(int articleId);
        Task<HttpStatusCode> LikeArticle(int articleId, int userId);
        Task<GenericResponse<object>> GetArticleLikes(int articleId);
    }
}