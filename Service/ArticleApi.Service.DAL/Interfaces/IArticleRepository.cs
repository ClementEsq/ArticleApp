using ArticleApi.Service.Models;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IArticleRepository : IRepository<Article, string>
    {
    }
}
