using ArticleApi.Service.DTO;
using ArticleApi.Service.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleApi.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Default")]
    public class ArticleController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet]
        public async Task<GenericResponse<object>> GetAllTopicAreas()
        {
            return await _articleService.GetAllArticles();
        }
    }
}
