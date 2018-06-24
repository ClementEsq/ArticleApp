using ArticleApi.Service.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;
using System.Net;
using ArticleApi.Service.DTO;
using ArticleApi.Service.DAL.Interfaces;
using ArticleApi.Service.DTO.Responses;

namespace ArticleApi.Service.Infrastructure
{
    public class LogInService : ILogInService
    {
        private readonly IUserRepository _userRepository;

        public LogInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponse<UserLoginResponse>> LogIn(string email, string password)
        {
            var response = new GenericResponse<UserLoginResponse>();

            try
            {
                using (_userRepository)
                {
                    response.Status = HttpStatusCode.OK;
                    response.Message = "Success";

                    var user = await _userRepository.GetUserByEmail(email);
                    var isValidUser = user?.Password.Equals(password);

                    response.Payload = isValidUser.Value ?
                        new UserLoginResponse()
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            UserEmail = user.UserEmail,
                            IsPublisher = user.IsPublisher
                        } : null;
                }
            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "Failed";
            }

            return response;
        }
    }
}
