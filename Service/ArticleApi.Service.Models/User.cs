namespace ArticleApi.Service.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsPublisher { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
