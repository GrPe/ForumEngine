using System;

namespace ForumEngine.Models
{
    public class PostSummaryViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ContentSummary { get; set; }
    }
}
