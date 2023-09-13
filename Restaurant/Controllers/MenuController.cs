using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Policy = "AlcoholAccess")]
        [HttpGet]
        public async Task<IActionResult> GetDishes(int page = 1, int pageSize = 10)
        {
            var totalItems = await _dishService.GetTotalDishCount(); 

            var response = await _dishService.GetDishes(page, pageSize); 

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var dishes = response.Data.ToList();

                ViewData["Page"] = page;
                ViewData["PageSize"] = pageSize;
                ViewData["TotalItems"] = totalItems;

                return View(dishes);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task <IActionResult> GetCategory(string category, int page = 1, int pageSize = 10)
        {
            var totalItems = await _dishService.GetTotalDishCount(category); 

            var response = await _dishService.GetDishes(category, page, pageSize); 

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                var allDishes = response.Data.ToList();

                
                var filteredDishes = allDishes.Where(item => item.Category.ToString() == category).ToList();

                
                ViewData["Page"] = page;
                ViewData["PageSize"] = pageSize;
                ViewData["TotalItems"] = totalItems;

                return View("GetDishes", filteredDishes);
            }

            return RedirectToAction("Index", "Home");
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
