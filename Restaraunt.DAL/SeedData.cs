using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Extensions;

namespace Restaurant.DAL
{

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Apply any pending migrations
                context.Database.EnsureCreated();

                if (context.Users.Any() && context.Dishes.Any() && context.Carts.Any() && context.Orders.Any())
                {
                    // Data already seeded
                    return;
                }


                // Seed User data
                context.Users.AddRange(
                    new User
                    {
                        Name = "Admin",
                        Password = HashPasswordHelper.HashPassowrd("123456"),
                        Role = Role.Admin
                    },
                    new User
                    {
                        Name = "Moderator",
                        Password = HashPasswordHelper.HashPassowrd("654321"),
                        Role = Role.Moderator
                    }
                );
                context.SaveChanges();

                context.Carts.AddRange((new Cart()
                {

                    UserId = 1
                }
                ));
                context.SaveChanges();

                // Seed Dish data
                context.Dishes.AddRange(
                   new Dish
                   {
                       Name = "Bread",
                       Description = new string('A', 50),
                       DateCreate = DateTime.Now,
                       Price = 2500,
                       Category = Category.Appetizers
                   },
                   new Dish
                   {
                       Name = "Wine",
                       Description = new string('A', 50),
                       DateCreate = DateTime.Now,
                       Category = Category.Beverages
                   },
                   new Dish
                   {
                       Name = "Pizza \"Paperoni\"",
                       Description = new string('A', 50),
                       DateCreate = DateTime.Now,
                       Price = 3000,
                       Category = Category.Pizza
                   },
                   new Dish
                   {
                       Name = "Beer \"Corona\"",
                       Description = new string('A', 50),
                       DateCreate = DateTime.Now,
                       Price = 120,
                       Category = Category.AlcoholicBeverages
                   },
                   new Dish
                   {
                       Name = "Mongolian Beef",
                       Description = new string('A', 50),
                       DateCreate = DateTime.Now,
                       Price = 3000,
                       Category = Category.MainCourses
                   }
               );
                context.SaveChanges();

                // Seed DishPhoto data
                string relativeImagePath1 = "img/DishPhotos/PizzaPaperoni.jpg";
                string relativeImagePath2 = "img/DishPhotos/bread.jpg";
                string relativeImagePath3 = "img/DishPhotos/WineTraverseBay.jpg";
                string relativeImagePath4 = "img/DishPhotos/BeerCorona.jpg";
                string relativeImagePath5 = "img/DishPhotos/MongolianBeef.jpg";

                byte[] imageData1 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath1));
                byte[] imageData2 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath2));
                byte[] imageData3 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath3));
                byte[] imageData4 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath4));
                byte[] imageData5 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath5));

                context.DishPhotos.AddRange(new DishPhoto[]
                {
                new DishPhoto
                {
                    DishId = 3,
                    ImageData = imageData1
                },
                new DishPhoto
                {
                    DishId = 1,
                    ImageData = imageData2
                },
                new DishPhoto
                {
                    DishId = 2,
                    ImageData = imageData3
                },
                new DishPhoto
                {
                    DishId = 4,
                    ImageData = imageData4
                },
                new DishPhoto
                {
                    DishId = 5,
                    ImageData = imageData5
                }
            });

               

                // Seed Order data
                var orders = new List<Order>();

                for (int i = 1; i <= 20; i++)
                {
                    orders.Add(new Order
                    {
                        DishId = 1,
                        DateCreated = DateTime.Now.AddDays(-i),
                        Address = $"Test Address {i}",
                        FirstName = $"First Name {i}",
                        LastName = $"Last Name {i}",
                        Phone = 1234567890 + i,
                        Post = $"Test Post {i}",
                        Payment = $"Test Payment {i}",
                        Comments = $"Test Comment {i}",
                        CartId = 1,
                        Quantity = i
                        
                    });
                }

                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }

    }
}