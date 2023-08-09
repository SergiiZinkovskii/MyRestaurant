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
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName);
        Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetAllItems();
        Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id);
        Task<IBaseResponse<OrderViewModel>> GetItemByAdmin(long id);
    }
}
