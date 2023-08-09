using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.Interfaces;

namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Detail()
        {
            var response = await _cartService.GetItems(User.Identity.Name);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AdminCartPage()
        {
            var response = await _cartService.GetAllItems();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data.ToList());
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> GetItem(long id)
        {
            var response = await _cartService.GetItem(User.Identity.Name, id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetItemByAdmin(long id)
        {
            var response = await _cartService.GetItemByAdmin(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView("GetItem", response.Data);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
