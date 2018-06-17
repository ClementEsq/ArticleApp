using System;

namespace ArticleApi.Service.Models
{
    public class ArticleLike
    {
        public int? Id { get; set; }
        public User User { get; set; }
        public Article Article { get; set; }
        public DateTime DateTime { get; set; }
    }
}
