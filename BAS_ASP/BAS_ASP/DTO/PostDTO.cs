using BAS_ASP.Models;
using System;
using System.Collections.Generic;

namespace BAS_ASP.DTO
{
    public class PostDTO
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public User user { get; set; }
        public int likes { get; set; }
        public List<Comment> comments { get; set; }
    }
}
