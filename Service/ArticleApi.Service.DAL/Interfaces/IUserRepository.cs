using ArticleApi.Service.Models;
using System.Collections.Generic;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User, string>
    {
        IEnumerable<User> FindAll();
        IEnumerable<User> Find(int id);
    }
}
