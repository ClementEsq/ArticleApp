using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApi.Service.DTO.Responses
{
    public class GenericPayload
    {
        public bool IsSuccess { get; set; }
        public string SpecificMessage { get; set; }
    }
}
