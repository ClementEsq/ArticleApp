using System;
using System.Data;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Guid Id { get; }
        IArticleRepositoryConnection RepositoryConnection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void Rollback();
    }
}
