using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.ViewModel;

namespace Restaurant.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            var model = new ChatViewModel();
            if (User.Identity.IsAuthenticated)
            {
                model.Author = User.Identity.Name;
            }
            else
            {
                model.Author = "User";
            }
            return View(model);
        }
    }
}
