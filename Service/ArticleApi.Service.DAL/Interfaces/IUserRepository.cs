using ArticleApi.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApi.Service.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetUserByEmail(string emailAdress);
    }
}
