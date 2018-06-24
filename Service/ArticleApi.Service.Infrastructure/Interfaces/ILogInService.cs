using ArticleApi.Service.DTO;
using System.Threading.Tasks;
using ArticleApi.Service.DTO.Responses;


namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface ILogInService
    {
        Task<GenericResponse<UserLoginResponse>> LogIn(string email, string password);
    }
}
