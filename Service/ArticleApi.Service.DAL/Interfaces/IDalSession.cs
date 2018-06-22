using System;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IDalSession : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
