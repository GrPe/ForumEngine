using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForumEngine.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string UserPhotoPath { get; set; }
        public List<string> Content { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public bool AllowEditing { get; set; }

        //permanent hack
        [Required(AllowEmptyStrings = false, ErrorMessage = "Comment cannot be empty")]
        public string NewCommentContent { get; set; }
    }
}
