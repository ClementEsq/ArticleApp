using ArticleApi.Service.Models;
using System;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User, int>, IDisposable
    {
        Task<User> GetUserByEmail(string emailAdress);
    }
}
