using ArticleApi.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IArticleRepository : IRepository<Article, int>, IArticleLikeRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
    }
}
