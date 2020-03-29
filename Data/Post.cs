using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumEngine.Data
{
    public class Post
    {
        public int Id { get; set; }
        public ForumUser User { get; set; }
        public string Content { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
