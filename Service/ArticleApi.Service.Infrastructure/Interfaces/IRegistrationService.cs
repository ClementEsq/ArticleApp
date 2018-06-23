using ArticleApi.Service.DTO.Requests;
using System.Threading.Tasks;
using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Responses;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface IRegistrationService
    {
        Task<GenericResponse<GenericPayload>> SignUp(SignUpRequest newUser);
    }
}
