using ArticleApi.Service.DTO.Requests;
using System.Threading.Tasks;
using ArticleApi.Service.DTO;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface IRegistrationService
    {
        Task<GenericResponse<string>> SignUp(SignUpRequest newUser);
    }
}
