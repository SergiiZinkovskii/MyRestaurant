using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.ViewModel;

namespace Restaurant.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            var model = new ChatViewModel();
            var user = model.Author;
            if (User.Identity.IsAuthenticated) { user = User.Identity.Name; }
            else { user = "User"; }
            return View(model);
        }
    }
}
