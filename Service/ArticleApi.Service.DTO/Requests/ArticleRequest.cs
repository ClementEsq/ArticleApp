using System.ComponentModel.DataAnnotations;

namespace ArticleApi.Service.DTO.Requests
{
    public class ArticleRequest
    {
        [Required]
        public int? ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        public string HeroImagePath { get; set; }

        public string BodyImagePath { get; set; }

        [Required]
        public int ArticleAuthorId { get; set; }
    }
}
