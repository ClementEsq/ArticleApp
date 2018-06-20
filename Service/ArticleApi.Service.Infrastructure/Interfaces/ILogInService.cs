using ArticleApi.Service.DTO;
using System.Threading.Tasks;
using System.Net;


namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface ILogInService
    {
        Task<HttpStatusCode> LogIn(string email, string password);
    }
}
