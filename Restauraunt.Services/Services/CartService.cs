using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Interfaces;
using Restaurant.Domain.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Services
{
    public class CartService : ICartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IDishPhotoRepository _dishPhotoRepository;
        private readonly IOrderRepository _orderRepository;

        public CartService(IUserRepository userRepository, IDishRepository dishRepository, IDishPhotoRepository photoRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _dishRepository = dishRepository;
            _dishPhotoRepository = photoRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetAllItems()
        {
            try
            {
                var orders = await _orderRepository.GetAll().ToListAsync();

                var response = from order in orders
                               join dish in _dishRepository.GetAll() on order.DishId equals dish.Id
                               join photo in _dishPhotoRepository.GetAll() on dish.Id equals photo.DishId into photos
                               from photo in photos.DefaultIfEmpty()
                               select new OrderViewModel()
                               {
                                   Id = order.Id,
                                   DishName = dish.Name,
                                   Category = dish.Category.GetDisplayName(),
                                   Photo = photo,
                                   Address = order.Address,
                                   FirstName = order.FirstName,
                                   LastName = order.LastName,
                                   MiddleName = order.MiddleName,
                                   DateCreate = order.DateCreated.ToLongDateString(),
                                   Phone = order.Phone,
                                   Price = dish.Price,
                                   Post = order.Post,
                                   Payment = order.Payment,
                                   Comments = order.Comments,
                                   Quantity = order.Quantity
                               };

                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<OrderViewModel>>> GetItems(string userName)
        {
            try
            {


                var user = await _userRepository.GetAll()

                    .Include(x => x.Cart)
                    .ThenInclude(x => x.Orders)
                    .FirstOrDefaultAsync(x => x.Name == userName);

                if (user == null)
                {
                    return new BaseResponse<IEnumerable<OrderViewModel>>()
                    {
                        Description = "Entity not found",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var orders = user.Cart?.Orders;
                var response = from p in orders
                               join c in _dishRepository.GetAll() on p.DishId equals c.Id
                               join photo in _dishPhotoRepository.GetAll() on c.Id equals photo.DishId into photos
                               from photo in photos.DefaultIfEmpty()
                               select new OrderViewModel()
                               {
                                   Id = p.Id,
                                   Price = c.Price,
                                   DishName = c.Name,
                                   Category = c.Category.GetDisplayName(),
                                   Photo = photo,
                               };

                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrderViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<OrderViewModel>> GetItem(string userName, long id)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(x => x.Cart)
                    .ThenInclude(x => x.Orders)
                    .FirstOrDefaultAsync(x => x.Name == userName);

                if (user == null)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Користувача не знайдено",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var orders = user.Cart?.Orders.Where(x => x.Id == id).ToList();
                if (orders == null || orders.Count == 0)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Замовлень немає",
                        StatusCode = StatusCode.OrderNotFound
                    };
                }

                var response = (from p in orders
                                join c in _dishRepository.GetAll() on p.DishId equals c.Id
                                join photo in _dishPhotoRepository.GetAll() on c.Id equals photo.DishId into photos
                                from photo in photos.DefaultIfEmpty()
                                select new OrderViewModel()
                                {
                                    Id = p.Id,
                                    DishName = c.Name,
                                    Category = c.Category.GetDisplayName(),
                                    Address = p.Address,
                                    FirstName = p.FirstName,
                                    LastName = p.LastName,
                                    MiddleName = p.MiddleName,
                                    DateCreate = p.DateCreated.ToLongDateString(),
                                    Photo = photo,
                                    Phone = p.Phone,
                                    Comments = p.Comments,
                                    Post = p.Post,
                                    Payment = p.Payment,
                                }).FirstOrDefault();

                return new BaseResponse<OrderViewModel>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<OrderViewModel>> GetItemByAdmin(long id)
        {
            try
            {
                var order = await _orderRepository.GetAll()
                    .FirstOrDefaultAsync(o => o.Id == id);

                if (order == null)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Order",
                        StatusCode = StatusCode.OrderNotFound
                    };
                }

                var product = await _dishRepository.GetAll()
                    .FirstOrDefaultAsync(p => p.Id == order.DishId);

                if (product == null)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Enyity no found",
                        StatusCode = StatusCode.EntityNotFiund
                    };
                }

                var response = new OrderViewModel()
                {
                    Id = order.Id,
                    Category = product.Category.GetDisplayName(),
                    Address = order.Address,
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    MiddleName = order.MiddleName,
                    DateCreate = order.DateCreated.ToLongDateString(),
                    Phone = order.Phone,
                    Comments = order.Comments,
                    Post = order.Post,
                    Payment = order.Payment,
                    Quantity = order.Quantity,
                };

                return new BaseResponse<OrderViewModel>()
                {
                    Data = response,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
