using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
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
        public IActionResult GetCategory(string category)
        {
            var response = _dishService.GetDishes();
            var list = response.Data;
            if (response.StatusCode != Domain.Enum.StatusCode.OK) return View("Error", $"{response.Description}");
            var newList = list.Where(item => item.Category.ToString() == category).ToList();
            return View("GetDishes", newList);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _dishService.DeleteDish(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetDishes");
            }

            return View("Error", $"{response.Description}");
        }


        [HttpGet]
        public async Task<IActionResult> Save(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
                return PartialView();

            var data = await _dishService.GetOneDishAsync(id, cancellationToken);

            var response = new Response<DishViewModel>();

            if (data == null)
            {
                response.Description = "Entity not found";
                response.StatusCode = Domain.Enum.StatusCode.UserNotFound;
            }
            else
            {
                response = new Response<DishViewModel>()
                {
                    StatusCode = Domain.Enum.StatusCode.OK,
                    Data = data
                };
            }

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }

            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(DishViewModel viewModel, IFormFile[] avatars)
        {
            ModelState.Remove("Id");
            ModelState.Remove("DateCreate");

            var imageDataList = new List<byte[]>();

            if (avatars is { Length: > 0 })
            {
                foreach (var avatar in avatars)
                {
                    using var binaryReader = new BinaryReader(avatar.OpenReadStream());
                    var imageData = binaryReader.ReadBytes((int)avatar.Length);
                    imageDataList.Add(imageData);
                }
            }

            await _dishService.Create(viewModel, imageDataList);
            return RedirectToAction("GetDishes");
        }


        [HttpGet]
        public async Task<IActionResult> GetOneDish(int id, CancellationToken cancellationToken)
        {
            var data = await _dishService.GetOneDishAsync(id, cancellationToken);
            return data != null
                ? View("GetOneDish", data)
                : View("Error", $"{"Entity not found"}");
        }

        [HttpPost]
        public async Task<IActionResult> GetOneDish(string term)
        {
            var response = await _dishService.GetOneDishAsync(term);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return Json(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        [HttpPost]
        public JsonResult GetTypes()
        {
            var types = _dishService.GetTypes();
            return Json(types.Data);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DishViewModel viewModel)
        {
            await _dishService.Edit(viewModel, viewModel.Id);
            return RedirectToAction("GetDishes");
        }

        public IActionResult SortedMenu()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddDish()
        {
            return View();
        }
    }
}
