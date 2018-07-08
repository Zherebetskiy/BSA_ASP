using BAS_ASP.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BAS_ASP.Controllers
{
    public class PostController:Controller
    {
        PostBL postBL;

        public PostController()
        {
            postBL = new PostBL();
        }

        public IActionResult Index(string id)
        {
            return View(postBL.GetPostById(id));
        }

        public IActionResult GetAllPost()
        {
            return View(postBL.GetAllPost());
        }
    }
}
