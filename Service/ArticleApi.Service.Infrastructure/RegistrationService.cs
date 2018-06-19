using System.Threading.Tasks;
using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.Infrastructure.Interfaces;
using ArticleApi.Service.DAL.Interfaces;
using System.Net;
using System;
using ArticleApi.Service.DTO.Helpers;

namespace ArticleApi.Service.Infrastructure
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponse<object>> SignUp(SignUpRequest newUser)
        {
            var response = new GenericResponse<object>();

            try
            {
                response.Status = HttpStatusCode.OK;
                response.Message = "Success";

                var user = DTOConverterHelper.CreateUserObjectFromRequest(newUser);
                await _userRepository.Save(user);
            }
            catch(Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
            }

            return response;
        }
    }
}
