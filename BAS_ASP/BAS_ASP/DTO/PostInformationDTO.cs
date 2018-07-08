using BAS_ASP.Models;

namespace BAS_ASP.DTO
{
    public class PostInformationDTO
    {
        public Post Post { get; set; }
        public Comment LongerComment { get; set; }
        public Comment LikerComment { get; set; }
        public int AmountOfComments { get; set; }
    }
}
