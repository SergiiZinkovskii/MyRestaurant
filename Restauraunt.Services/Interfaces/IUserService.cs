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
    public interface IUserService
    {
        Task<IBaseResponse<User>> CreateAsync(UserViewModel model);
        BaseResponse<Dictionary<int, string>> GetRoles();
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsersAsync();
        Task<IBaseResponse<bool>> DeleteUserAsync(long id);
    }
}
