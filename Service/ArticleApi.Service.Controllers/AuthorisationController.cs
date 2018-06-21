using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleApi.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthorisationController : Controller
    {
        private readonly ILogInService _logInService;

        public AuthorisationController(ILogInService logInService)
        {
            _logInService = logInService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<GenericResponse<bool>>> Login([FromBody]LoginRequest lr)
        {

            var response = await _logInService.LogIn(lr.Email, lr.Password);

            return response;
        }
    }
}
