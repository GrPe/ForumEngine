using System;
using System.Collections.Generic;

namespace ForumEngine.Data.DTO
{
    public class Post
    {
        public Guid Id { get; set; }
        public ForumUser User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
