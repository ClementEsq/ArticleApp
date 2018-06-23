using System.Threading.Tasks;
using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.Infrastructure.Interfaces;
using ArticleApi.Service.DAL.Interfaces;
using System.Net;
using System;
using ArticleApi.Service.DTO.Helpers;
using ArticleApi.Service.DTO.Responses;

namespace ArticleApi.Service.Infrastructure
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponse<GenericPayload>> SignUp(SignUpRequest newUser)
        {
            var response = new GenericResponse<GenericPayload>();

            try
            {
                using (_userRepository)
                {
                    response.Status = HttpStatusCode.OK;
                    response.Message = "Success";
                    var payload = new GenericPayload()
                    {
                        IsSuccess = false,
                    };

                    var isCreated = await TryCreateUser(_userRepository, newUser);

                    payload.IsSuccess = isCreated;
                    payload.SpecificMessage = isCreated ? "User created" : $"Unable to create user {newUser.UserEmail}";

                    response.Payload = payload;
                }
            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
            }

            return response;
        }

        private async Task<bool> TryCreateUser(IUserRepository repository, SignUpRequest newUser)
        {
            var user = await repository.GetUserByEmail(newUser.UserEmail);
            var isCreated = false;
            if (user == null)
            {
                user = DTOConverterHelper.CreateUserObjectFromRequest(newUser);
                await repository.Save(user);
                isCreated = true;
            }

            return isCreated;
        }
    }
}
