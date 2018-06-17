using System;

namespace ArticleApi.Service.Models
{
    public class Article
    {
        public int? ArticleId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? CrDate { get; set; }
        public string HeroImagePath { get; set; }
        public string BodyImagePath { get; set; }
        public int ArticleLikeCount { get; set; }
        public User User { get; set; }
    }
}
