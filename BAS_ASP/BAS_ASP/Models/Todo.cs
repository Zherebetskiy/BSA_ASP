using System;

namespace BAS_ASP.Models
{
    public class Todo
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public bool isComplete { get; set; }
        public int userId { get; set; }

    }
}
