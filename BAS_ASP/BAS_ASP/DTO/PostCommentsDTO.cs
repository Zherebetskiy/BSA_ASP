using BAS_ASP.Models;

namespace BAS_ASP.DTO
{
    public class PostCommentsDTO
    {
        public Post post { get; set; }
        public int amountOfComments { get; set; }
    }
}
