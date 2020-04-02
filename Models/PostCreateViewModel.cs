using Microsoft.AspNetCore.Http;

namespace ForumEngine.Models
{
    public class PostCreateViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
    }
}
