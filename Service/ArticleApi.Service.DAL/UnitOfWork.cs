using ArticleApi.Service.DAL.Interfaces;
using System;
using System.Data;

namespace ArticleApi.Service.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IArticleRepositoryConnection _articleRepositoryConnection;

        private IDbTransaction _transaction;
        private Guid _id = Guid.Empty;

        public UnitOfWork(IArticleRepositoryConnection articleRepositoryConnection)
        {
            _id = Guid.NewGuid();
            _articleRepositoryConnection = articleRepositoryConnection;
        }

        public Guid Id
        {
            get
            {
                return _id;
            }
        }

        public IArticleRepositoryConnection RepositoryConnection
        {
            get
            {
                return _articleRepositoryConnection;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        public void Begin()
        {
            _transaction = _articleRepositoryConnection.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            _transaction = null;
        }
    }
}
