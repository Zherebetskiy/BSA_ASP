using BAS_ASP.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BAS_ASP.Controllers
{
    public class TodoController:Controller
    {
        TodoBL todoBL;

        public TodoController()
        {
            todoBL = new TodoBL();
        }

        public IActionResult Index(string id)
        {
            return View(todoBL.GetTodoById(id));
        }
    }
}
