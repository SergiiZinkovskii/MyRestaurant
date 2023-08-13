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
        Task<IResponse<User>> CreateAsync(UserViewModel model);
        Response<Dictionary<int, string>> GetRoles();
        Task<Response<IEnumerable<UserViewModel>>> GetUsersAsync();
        Task<IResponse<bool>> DeleteUserAsync(long id);
    }
}
