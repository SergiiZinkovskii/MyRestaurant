using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
