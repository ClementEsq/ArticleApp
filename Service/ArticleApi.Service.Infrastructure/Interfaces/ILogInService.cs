using ArticleApi.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface ILogInService
    {
        Task<GenericResponse<object>> LogIn(string email, string password);
    }
}
