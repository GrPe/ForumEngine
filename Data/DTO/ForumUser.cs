using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ForumEngine.Data.DTO
{
    public class ForumUser : IdentityUser
    {
        public string Bio { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
