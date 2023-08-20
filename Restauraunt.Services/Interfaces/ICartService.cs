using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Interfaces
{
    public interface ICartService
    {
        Task<IResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);
        Task<IResponse<IEnumerable<OrderViewModel>>> GetAllItems(int page, int pageSize);
        Task<IResponse<OrderViewModel>> GetItem(string userName, long id);
        Task<IResponse<OrderViewModel>> GetItemByAdmin(long id);
        Task<int> GetTotalOrderCount();
    }
}
