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

        public async Task<GenericResponse<string>> SignUp(SignUpRequest newUser)
        {
            var response = new GenericResponse<string>();

            try
            {
                using (_userRepository)
                {
                    response.Status = HttpStatusCode.OK;
                    response.Message = "Success";
                    response.Payload = $"User with the email address '{newUser.UserEmail}' already exists";


                    var user = await _userRepository.GetUserByEmail(newUser.UserEmail);

                    if (user == null)
                    {
                        user = DTOConverterHelper.CreateUserObjectFromRequest(newUser);
                        await _userRepository.Save(user);
                        response.Payload = $"User created";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
                response.Payload = $"User not created";
            }

            return response;
        }
    }
}
