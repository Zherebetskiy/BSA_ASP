using BAS_ASP.Data;
using BAS_ASP.DTO;
using BAS_ASP.Models;
using System.Collections.Generic;
using System.Linq;

namespace BAS_ASP.BusinessLogic
{
    public class PostBL
    {
        DataContext dataContext = DataContext.Instance;

        public Post GetPostById(string id)
        {
            return dataContext.Users.SelectMany(u => u.posts).Where(p => p.id == id).FirstOrDefault();
        }

        public List<PostDTO> GetAllPost()
        {
            var result = from post in dataContext.Posts
                         join comment in dataContext.Comments on int.Parse(post.id) equals comment.postId into postComment
                         select new PostDTO()
                         {
                             id = post.id,
                             createdAt = post.createdAt,
                             title = post.title,
                             body = post.body,
                             user = dataContext.Users.Where(u => int.Parse(u.id) == post.userId).FirstOrDefault(),
                             likes = post.likes,
                             comments = postComment.ToList()
                         };
                        
            return result.ToList();
        }
    }
}
