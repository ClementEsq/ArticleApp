using System.Data;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IArticleRepositoryConnection
    {
        IDbConnection Connection { get; }
    }
}
