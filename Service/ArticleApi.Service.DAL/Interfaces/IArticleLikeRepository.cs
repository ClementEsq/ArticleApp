using ArticleApi.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IArticleLikeRepository
    {
        Task<IEnumerable<ArticleLike>> GetAllArticleLikes(int articleId);
        Task RemoveArticleLike(int articleId, int userId);
        Task AddArticleLike(int articleId, int userId);
    }
}
