using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Interfaces;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Response;
using Restaurant.Domain.ViewModel;
using Restaurant.Services.Interfaces;

namespace Restaurant.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUserRepository userRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse<Order>> Create(CreateOrderViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll()
                                 .Include(x => x.Cart)
                                 .FirstOrDefaultAsync(x => x.Name == model.Login);

                if (user == null)
                {
                    return new Response<Order>()
                    {
                        Description = "User Not Found",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var order = new Order()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    DateCreated = DateTime.Now,
                    CartId = user.Cart.Id,
                    DishId = model.DishId,
                    Phone = model.Phone,
                    Post = model.Post,
                    Payment = model.Payment,
                    Comments = model.Comments
                };

                await _orderRepository.Create(order);
                await _unitOfWork.CommitAsync();

                return new Response<Order>()
                {
                    Description = "Order created",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new Response<Order>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IResponse<bool>> Delete(long id)
        {
            try
            {
                var order = _orderRepository.GetAll()
                    .Include(x => x.Cart)
                    .FirstOrDefault(x => x.Id == id);

                if (order == null)
                {
                    return new Response<bool>()
                    {
                        StatusCode = StatusCode.OrderNotFound,
                        Description = "Order not found"
                    };
                }

                await _orderRepository.Delete(order);
                await _unitOfWork.CommitAsync();
                return new Response<bool>()
                {
                    StatusCode = StatusCode.OK,
                    Description = "Order deleted"
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
