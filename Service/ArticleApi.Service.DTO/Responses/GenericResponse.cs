using System.Net;

namespace ArticleApi.Service.DTO
{
    public class GenericResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public T Payload { get; set; }

        public static GenericResponse<T> Success(T payload)
        {
            return new GenericResponse<T>
            {
                Status = HttpStatusCode.OK,
                Message = "Success",
                Payload = payload
            };
        }

        public static GenericResponse<T> Failure()
        {
            return new GenericResponse<T>
            {
                Status = HttpStatusCode.Forbidden,
                Message = "Failure"
            };
        }
    }
}
