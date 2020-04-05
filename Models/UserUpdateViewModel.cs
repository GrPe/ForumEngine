using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using ForumEngine.Extentions;

namespace ForumEngine.Models
{
    public class UserUpdateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }
        [AllowedExtentions(new string[] { ".png", ".jpg" })]
        [MaxFileSize(1 * 1024 * 1024)]
        public IFormFile Image { get; set; }
    }
}
