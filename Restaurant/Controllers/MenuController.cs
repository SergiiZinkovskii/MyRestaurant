using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Response;
using Restaurant.Services.Interfaces;

namespace Restaurant.Controllers
{
    public class MenuController : Controller

    {
        private readonly IDishService _dishService;

        public MenuController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public IActionResult GetDishes()
        {
            var response = _dishService.GetDishes();
            return response.StatusCode == Domain.Enum.StatusCode.OK
                ? View(response.Data)
                : View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> GetOneDish(int id, CancellationToken cancellationToken)
        {
            var data = await _dishService.GetOneDishAsync(id, cancellationToken);
            return data != null
                ? View("GetOneDish", data)
                : View("Error", $"{"Товар не знайдено"}");
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
