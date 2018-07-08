using System;
using System.Collections.Generic;

namespace BAS_ASP.Models
{
    public class User
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public List<Todo> todos { get; set; }
        public List<Post> posts { get; set; }
    }
}
