using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IDalSession : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
