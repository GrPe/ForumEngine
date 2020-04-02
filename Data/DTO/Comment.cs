using System;

namespace ForumEngine.Data.DTO
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public ForumUser User { get; set; }
        public string Content { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
