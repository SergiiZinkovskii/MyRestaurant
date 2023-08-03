using Restaurant.Domain.Entity;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public interface IDishService
    {
        BaseResponse<Dictionary<int, string>> GetTypes();
        IBaseResponse<List<Dish>> GetDishes();
        Task<DishViewModel?> GetOneDishAsync(long id,
            CancellationToken cancellationToken);
        Task<BaseResponse<Dictionary<long, string>>> GetOneDishAsync(string term);
        Task<IBaseResponse<Dish>> Create(DishViewModel model, List<byte[]> imageDataList);
        Task<IBaseResponse<bool>> DeleteDish(long id);
        Task<IBaseResponse<Dish>> Edit(DishViewModel model, long Id);
    }
}
