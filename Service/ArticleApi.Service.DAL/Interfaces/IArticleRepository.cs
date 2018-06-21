using ArticleApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IArticleRepository : IRepository<Article, int>, IArticleLikeRepository, IDisposable
    {
        Task<IEnumerable<Article>> GetAllArticles();
    }
}
