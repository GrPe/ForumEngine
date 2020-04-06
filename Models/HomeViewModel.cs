using System.Collections.Generic;

namespace ForumEngine.Models
{
    public class HomeViewModel
    {
        public List<PostSummaryViewModel> Posts { get; set; }
        public int CurrentPage { get; set; }
        public int MaxPage { get; set; }
    }
}
