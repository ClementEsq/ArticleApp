using ArticleApi.Service.DTO.Requests;
using System.Threading.Tasks;
using System.Net;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface IRegistrationService
    {
        Task<HttpStatusCode> SignUp(SignUpRequest newUser);
    }
}
