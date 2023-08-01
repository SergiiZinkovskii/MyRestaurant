using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Interfaces;

namespace Restaurant.Services.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public IBaseResponse<List<Dish>> GetDishes()
        {
            try
            {
                
                var dishes = _dishRepository.GetAll()
                    .Include(p => p.DishPhotos)
                    .ToList();

                if (!dishes.Any())
                {
                    return new BaseResponse<List<Dish>>()
                    {
                        Description = "We find 0 elements",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Dish>>()
                {
                    Data = dishes,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Dish>>()
                {
                    Description = $"[GetProducts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<DishViewModel?> GetOneDishAsync(long id,
    CancellationToken cancellationToken)
        {
            var dish = await _dishRepository.Find(id, cancellationToken);

            if (dish == null)
            {
                return null;
            }

            return new DishViewModel()
            {
                Id = dish.Id,
                //DateCreate = dish.DateCreate.ToLongDateString(),
                Description = dish.Description,
                Name = dish.Name,
                Price = dish.Price,
                //Comments = await _commentRepository.FindAsync(product.Id),
                Photos = dish.DishPhotos.Select(p => p.ImageData).ToList() 
            };
        }




    }
}
