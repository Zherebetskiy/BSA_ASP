using BAS_ASP.Models;

namespace BAS_ASP.DTO
{
    public class UserInfirmationDTO
    {
        public User User { get; set; }
        public Post LastPost { get; set; }
        public int AmountOfComm { get; set; }
        public int UncompletedTasks { get; set; }
        public Post PopularPostByComm { get; set; }
        public Post PopularPostByLikes { get; set; }
    }
}
