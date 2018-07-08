using Microsoft.AspNetCore.Mvc;
using BAS_ASP.BusinessLogic;

namespace BAS_ASP.Controllers
{
    public class UserController:Controller
    {
        UserBL userBL;

        public UserController()
        {
            userBL = new UserBL();
        }

        public IActionResult Index(string id)
        {
            return View(userBL.GetUserById(id));
        }

        //1
        public IActionResult GetAmountOfCommentsByUserId(string id)
        {
            return View(userBL.GetAmountOfCommentsByUserId(id));
        }
              
        //2
        public IActionResult AllComments(string id, int length)
        {
            return View(userBL.GetAllCommentsByUserId(id, length));
        }

        //3
        public IActionResult CompletedTodos(string id)
        {
            return View(userBL.GetTodosByUserId(id));
        }

        //4
        public IActionResult SortedUsers()
        {
            return View(userBL.GetListOfUsers());
        }

        //5
        public IActionResult UserInformation(string id, int length)
        {
            return View(userBL.GetUserInformation(id, length));
        }

        //6
        public IActionResult PostInformation(string id, int length)
        {
            return View(userBL.GetPostInformation(id, length));
        }
    }
}
