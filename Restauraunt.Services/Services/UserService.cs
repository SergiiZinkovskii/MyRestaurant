using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Extensions;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Services
{
    public class UserService : IUserService
    {

        private readonly ILogger<UserService> _logger;
        private readonly IProfileRepository _proFileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository,
            IProfileRepository proFileRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userRepository = userRepository;
            _proFileRepository = proFileRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<User>> CreateAsync(UserViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user != null)
                {
                    return new Response<User>()
                    {
                        Description = "User wis this password already exist",
                        StatusCode = StatusCode.UserAlreadyExists
                    };
                }
                user = new User()
                {
                    Name = model.Name,
                    Role = Enum.Parse<Role>(model.Role),
                    Password = HashPasswordHelper.HashPassowrd(model.Password),
                };

                await _userRepository.Create(user);

                var profile = new Profile()
                {
                    Address = string.Empty,
                    Age = 0,
                    UserId = user.Id,
                };

                await _proFileRepository.Create(profile);

                return new Response<User>()
                {
                    Data = user,
                    Description = "User was added",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserService.CreateAsync] error: {ex.Message}");
                return new Response<User>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"internal error: {ex.Message}"
                };
            }
        }

        public Response<Dictionary<int, string>> GetRoles()
        {
            try
            {
                var roles = ((Role[])Enum.GetValues(typeof(Role)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new Response<Dictionary<int, string>>()
                {
                    Data = roles,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<Response<IEnumerable<UserViewModel>>> GetUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAll()
                    .Select(x => new UserViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Role = x.Role.GetDisplayName()
                    })
                    .ToListAsync();

                _logger.LogInformation($"[UserService.GetUsers] getting elements {users.Count}");
                return new Response<IEnumerable<UserViewModel>>()
                {
                    Data = users,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.GetUsers] error: {ex.Message}");
                return new Response<IEnumerable<UserViewModel>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"internal error: {ex.Message}"
                };
            }
        }

        public async Task<IResponse<bool>> DeleteUserAsync(long id)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    return new Response<bool>
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }
                await _userRepository.Delete(user);
                _logger.LogInformation($"[UserService.DeleteUser] user was deleted");

                return new Response<bool>
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserSerivce.DeleteUser] error: {ex.Message}");
                return new Response<bool>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"internal error: {ex.Message}"
                };
            }
        }


    }
}
