using ArticleApi.Service.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;
using System.Net;
using ArticleApi.Service.DTO;
using ArticleApi.Service.DAL.Interfaces;

namespace ArticleApi.Service.Infrastructure
{
    public class LogInService : ILogInService
    {
        private readonly IUserRepository _userRepository;

        public LogInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GenericResponse<object>> LogIn(string email, string password)
        {
            var response = new GenericResponse<object>();

            try
            {
                response.Status = HttpStatusCode.OK;
                response.Message = "Success";

                var user = await _userRepository.GetUserByEmail(email);
                var isValidUser = user.Password.Equals(password);

                response.Payload = isValidUser;
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
