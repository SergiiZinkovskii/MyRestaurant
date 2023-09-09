using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    public class SiteController : Controller
    {
        //[Authorize]
        public string Secret()
        {
            return "Secret string from Orders API";
        }
    }
}
