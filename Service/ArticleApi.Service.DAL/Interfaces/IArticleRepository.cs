using ArticleApi.Service.Models;
using System.Collections.Generic;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IArticleRepository : IRepository<Article, string>
    {
        IEnumerable<User> FindAll();
        IEnumerable<User> Find(int id);
    }
}
