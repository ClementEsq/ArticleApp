using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Service.DTO.Requests
{
    public class EditUserRequest : UserRequest
    {
        public int? UserId { get; set; }
    }
}
