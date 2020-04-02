using System;
using System.Collections.Generic;

namespace ForumEngine.Models
{
    public class CommentViewModel
    {
        public string UserName { get; set; }
        public string UserPhotoPath { get; set; }
        public List<string> Content { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
