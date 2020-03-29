using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumEngine.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public ForumUser User { get; set; }
        public string Context { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
