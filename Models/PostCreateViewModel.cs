using ForumEngine.Extentions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ForumEngine.Models
{
    public class PostCreateViewModel
    {
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        public string Content { get; set; }
        [AllowedExtentions(extentions: new string[] { "jpg", "png" })]
        [MaxFileSize(maxFileSize: 1 * 1024 * 1024)]
        public IFormFile Image { get; set; }
    }
}
