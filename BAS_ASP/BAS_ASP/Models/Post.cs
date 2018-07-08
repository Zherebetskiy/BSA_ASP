using System;
using System.Collections.Generic;

namespace BAS_ASP.Models
{
    public class Post
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public int likes { get; set; }
        public List<Comment> comments { get; set; }
    }
}
