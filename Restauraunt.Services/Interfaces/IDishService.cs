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
        IBaseResponse<List<Dish>> GetDishes();
        Task<DishViewModel?> GetOneDishAsync(long id,
    CancellationToken cancellationToken);
    }
}
