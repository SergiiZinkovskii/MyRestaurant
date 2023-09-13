using Restaurant.Domain.Entity;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;


namespace Restaurant.Services.Interfaces
{
    public interface IDishService
    {
        Response<Dictionary<int, string>> GetTypes();
        Task<IResponse<IEnumerable<Dish>>> GetDishes(int page, int pageSize);
        Task<IResponse<IEnumerable<Dish>>> GetDishes(string category, int page, int pageSize);
        Task<DishViewModel?> GetOneDishAsync(long id,
            CancellationToken cancellationToken);
        Task<Response<Dictionary<long, string>>> GetOneDishAsync(string term);
        Task<IResponse<Dish>> Create(DishViewModel model, List<byte[]> imageDataList);
        Task<IResponse<bool>> DeleteDish(long id);
        Task<IResponse<Dish>> Edit(DishViewModel model, long Id);
        Task<int> GetTotalDishCount();
        Task<int> GetTotalDishCount(string category);
    }
}
