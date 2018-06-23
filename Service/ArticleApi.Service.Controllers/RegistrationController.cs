using ArticleApi.Service.DTO;
using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.DTO.Responses;
using ArticleApi.Service.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleApi.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult<GenericResponse<GenericPayload>>> SignUp([FromBody]SignUpRequest sur)
        {

            var response = await _registrationService.SignUp(sur);

            return response;
        }
    }
}
