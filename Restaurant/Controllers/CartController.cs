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

        public async Task<IActionResult> AdminCartPage(int page = 1, int pageSize = 10)
        {
            var totalItems = await _cartService.GetTotalOrderCount();

            var response = await _cartService.GetAllItems(page, pageSize);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var orders = response.Data.ToList();

                ViewData["Page"] = page;
                ViewData["PageSize"] = pageSize;
                ViewData["TotalItems"] = totalItems;

                return View(orders);
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
