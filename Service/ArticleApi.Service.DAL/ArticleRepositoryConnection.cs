using ArticleApi.Service.DAL.Interfaces;
using System.Data;

namespace ArticleApi.Service.DAL
{
    public class ArticleRepositoryConnection : IArticleRepositoryConnection
    {
        public ArticleRepositoryConnection(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection { get; }
    }
}
