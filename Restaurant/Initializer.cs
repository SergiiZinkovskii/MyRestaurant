using Restaurant.DAL;
using Restaurant.DAL.Interfaces;
using Restaurant.DAL.Repositories;
using Restaurant.Services.Interfaces;
using Restaurant.Services.Services;

namespace Restaurant
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IDishPhotoRepository, DishPhotoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDishService,  DishService>();
            services.AddScoped<IAccountService, AccountService>();

        }
    }
}
