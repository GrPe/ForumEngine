using System;
using System.ComponentModel.DataAnnotations;

namespace ForumEngine.Models
{
    public class PostEditViewModel
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
