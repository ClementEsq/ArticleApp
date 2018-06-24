namespace ArticleApi.Service.DTO.Responses
{
    public class UserLoginResponse
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPublisher { get; set; }
        public string UserEmail { get; set; }
    }
}
