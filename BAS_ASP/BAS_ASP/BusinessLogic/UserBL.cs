using BAS_ASP.Data;
using BAS_ASP.DTO;
using BAS_ASP.Models;
using System.Collections.Generic;
using System.Linq;

namespace BAS_ASP.BusinessLogic
{
    public class UserBL
    {
        DataContext dataContext = DataContext.Instance;

        public IEnumerable<User> GetAllUser()
        {
            return dataContext.Users;
        }

        public User GetUserById(string id)
        {
            return dataContext.Users.Where(u=>u.id==id).FirstOrDefault();
        }

        //1
        public List<PostCommentsDTO> GetAmountOfCommentsByUserId(string id)
        {
            var amountOfComments = dataContext.Posts
              .Where(p => p.userId.ToString() == id)
              .GroupJoin(dataContext.Comments,
                  p => p.id,
                  c => c.postId.ToString(),
                  (p, c) => new PostCommentsDTO
                  {
                      post = p,
                      amountOfComments = c.Count()
                  });

            return amountOfComments.ToList();
        }

        //2
        public IEnumerable<Comment> GetAllCommentsByUserId(string id, int length)
        {
            var comments = dataContext.Users.Where(u => u.id == id)
                .SelectMany(u => u.posts.SelectMany(p => p.comments.Where(c => c.body.Length < length)));

            return comments;
        }

        //3
        public IEnumerable<Todo> GetTodosByUserId(string id)
        {
            var todos = dataContext.Users.Where(u =>u.id == id)
                .SelectMany(u => u.todos.Where(t => t.isComplete == true));

            return todos;
        }

        //4
        public List<User> GetListOfUsers()
        {
            var result = dataContext.Users.Select(user => new User()
            {
                id = user.id,
                createdAt = user.createdAt,
                name = user.name,
                avatar = user.avatar,
                posts = user.posts,
                todos = user.todos.OrderByDescending(t=>t.name.Length).ToList()
            }).OrderBy(u=>u.name).ToList(); 
                      
            return result;
        }


        //5
        public UserInformationDTO GetUserInformation(string id, int length)
        {
            var result = dataContext.Users.Where(u => u.id == id)
                .Select(u => new UserInformationDTO()
                {
                    User = u,
                    LastPost = u.posts.OrderByDescending(p => p.createdAt).FirstOrDefault(),
                    AmountOfComm = u.posts.OrderByDescending(p => p.createdAt).FirstOrDefault().comments.Count(),
                    UncompletedTasks = u.todos.Where(t => t.isComplete == false).Count(),
                    PopularPostByComm = u.posts.OrderBy(p => p.comments.Where(c => c.body.Length > length).Count()).FirstOrDefault(),
                    PopularPostByLikes = u.posts.OrderByDescending(p => p.likes).FirstOrDefault()
                }).FirstOrDefault();

            return result;
        }

        //6
        public PostInformationDTO GetPostInformation(string id, int length)
        {
            var post = dataContext.Users.SelectMany(u => u.posts)
                .Where(p => p.id == id)
                .Select(p => new PostInformationDTO()
                {
                    Post = p,
                    LongerComment = p.comments.OrderByDescending(c => c.body).FirstOrDefault(),
                    LikerComment = p.comments.OrderByDescending(c => c.likes).FirstOrDefault(),
                    AmountOfComments = p.comments.Where(cm => cm.likes == 0 || cm.body.Length < length).Count()
                })
                .FirstOrDefault();

            return post;
        }
    }
}
