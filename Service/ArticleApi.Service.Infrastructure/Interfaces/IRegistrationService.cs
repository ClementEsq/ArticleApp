using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using System.Threading.Tasks;

namespace ArticleApi.Service.Infrastructure.Interfaces
{
    public interface IRegistrationService
    {
        Task<GenericResponse<object>> SignUp(SignUpRequest newUser);
    }
}
