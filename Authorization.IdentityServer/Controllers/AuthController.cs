using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.ViewModel;

namespace Authorization.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }
    }
}
