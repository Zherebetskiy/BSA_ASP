using System;

namespace BAS_ASP.Models
{
    public class Comment
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public int postId { get; set; }
        public int likes { get; set; }
    }
}
