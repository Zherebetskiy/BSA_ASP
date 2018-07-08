using BAS_ASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BAS_ASP.Data
{
    public class DataContext
    {
        HttpClient client = new HttpClient();
        string userResponse;
        string postResponse;
        string commentResponse;
        string todoResponse;

        static Lazy<DataContext> dataContext = new Lazy<DataContext>(() => new DataContext());

        public static DataContext Instance { get { return dataContext.Value; } }


        public List<User> Users { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }
        public List<Todo> Todos { get; set; }

        private DataContext()
        {
            GetUserList().Wait();
            GetPostResponse().Wait();
            GetCommentResponse().Wait();
            GetTodoResponse().Wait();
            BuilHierarchy();
        }

        void BuilHierarchy()
        {
            var users = from user in Users
                        join post in (from p in Posts
                                      join comment in Comments on int.Parse(p.id) equals comment.postId into postComment
                                      select new Post()
                                      {
                                          id = p.id,
                                          createdAt = p.createdAt,
                                          title = p.title,
                                          body = p.body,
                                          userId = p.userId,
                                          likes = p.likes,
                                          comments = postComment.ToList()
                                      }) on int.Parse(user.id) equals post.userId into postComments
                        join todo in Todos on int.Parse(user.id) equals todo.userId into todos
                        select new User()
                        {
                            id = user.id,
                            createdAt = user.createdAt,
                            name = user.name,
                            avatar = user.avatar,
                            posts = postComments.ToList(),
                            todos = todos.ToList()
                        };

            Users = users.ToList();
        }

        async Task GetUserList()
        {
            userResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/users"));
            Users = JsonConvert.DeserializeObject<List<User>>(userResponse);
        }

        async Task GetPostResponse()
        {
            postResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/posts"));
            Posts = JsonConvert.DeserializeObject<List<Post>>(postResponse);
        }

        async Task GetCommentResponse()
        {
            commentResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/comments"));
            Comments = JsonConvert.DeserializeObject<List<Comment>>(commentResponse);
        }

        async Task GetTodoResponse()
        {
            todoResponse = await client.GetStringAsync(new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/todos"));
            Todos = JsonConvert.DeserializeObject<List<Todo>>(todoResponse);
        }
    }
}
