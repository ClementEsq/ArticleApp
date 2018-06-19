using System.ComponentModel.DataAnnotations;

namespace ArticleApi.Service.DTO.Requests
{
    public class UserRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsPublisher { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}
