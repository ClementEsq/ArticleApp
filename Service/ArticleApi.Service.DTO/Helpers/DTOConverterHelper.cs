using ArticleApi.Service.DTO.Requests;
using ArticleApi.Service.Models;

namespace ArticleApi.Service.DTO.Helpers
{
    public static class DTOConverterHelper
    {
        public static User CreateUserObjectFromRequest(SignUpRequest newUser)
        {
            return new User()
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                IsPublisher = newUser.IsPublisher,
                UserEmail = newUser.UserEmail,
                Password = newUser.Password
            };
        }

        public static Article CreateArticleObjectFromRequest(ArticleRequest articleRequest)
        {
            return new Article()
            {
                ArticleId = articleRequest.ArticleId,
                Title = articleRequest.Title,
                Body = articleRequest.Body,
                BodyImagePath = articleRequest.BodyImagePath,
                HeroImagePath = articleRequest.HeroImagePath,
                IsPublished = articleRequest.IsPublished,
                User = new User() { UserId = articleRequest.ArticleAuthorId }
            };
        }
    }
}
