using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Extensions;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Interfaces;
using System.Security.Claims;

namespace Restaurant.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ILogger<AccountService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUserRepository userRepository,
            ILogger<AccountService> logger, IProfileRepository profileRepository, 
            ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _logger = logger;
            _profileRepository = profileRepository;
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user != null)
                {
                    return new Response<ClaimsIdentity>()
                    {
                        Description = "User with this login or password already exists",
                    };
                }

                user = new User()
                {
                    Name = model.Name,
                    Role = Role.User,
                    Password = HashPasswordHelper.HashPassowrd(model.Password),
                };

                await _userRepository.Create(user);
                await _unitOfWork.CommitAsync();

                var profile = new Profile()
                {
                    UserId = user.Id,
                };

                var cart = new Cart()
                {
                    UserId = user.Id
                };

                await _profileRepository.Create(profile);
                await _unitOfWork.CommitAsync();
                await _cartRepository.Create(cart);
                await _unitOfWork.CommitAsync();
                var result = Authenticate(user);

                return new Response<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "added",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new Response<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<Response<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (user == null)
                {
                    return new Response<ClaimsIdentity>()
                    {
                        Description = "No user found"
                    };
                }

                if (user.Password != HashPasswordHelper.HashPassowrd(model.Password))
                {
                    return new Response<ClaimsIdentity>()
                    {
                        Description = "Incorrect login or password"
                    };
                }
                var result = Authenticate(user);

                return new Response<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new Response<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<Response<bool>> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.UserName);
                if (user == null)
                {
                    return new Response<bool>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "User not found"
                    };
                }

                user.Password = HashPasswordHelper.HashPassowrd(model.NewPassword);
                await _userRepository.Update(user);
                await _unitOfWork.CommitAsync();

                return new Response<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Password updated"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
                return new Response<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
        new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString("yyyy-MM-dd")),

    };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

    }
}
