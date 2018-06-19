using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleApi.Service.DTO.Requests
{
    public class SignUpRequest : UserRequest
    {
        [Required]
        public string Password { get; set; }
    }
}
