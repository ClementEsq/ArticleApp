using System.ComponentModel.DataAnnotations;

namespace ArticleApi.Service.DTO.Requests
{
    public class SignUpRequest : UserRequest
    {
        [Required]
        public string Password { get; set; }
    }
}
