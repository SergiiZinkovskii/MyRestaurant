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
        Response<Dictionary<int, string>> GetTypes();
        IResponse<List<Dish>> GetDishes();
        Task<DishViewModel?> GetOneDishAsync(long id,
            CancellationToken cancellationToken);
        Task<Response<Dictionary<long, string>>> GetOneDishAsync(string term);
        Task<IResponse<Dish>> Create(DishViewModel model, List<byte[]> imageDataList);
        Task<IResponse<bool>> DeleteDish(long id);
        Task<IResponse<Dish>> Edit(DishViewModel model, long Id);
    }
}
