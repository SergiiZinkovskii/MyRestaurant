using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Extensions;

namespace Restaurant.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishPhoto> DishPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("Users").HasKey(x => x.Id);

                builder.HasData(new User[]
                {
                    new User()
                    {
                        Id = 1,
                        Name = "Admin",
                        Password = HashPasswordHelper.HashPassowrd("123456"),
                        Role = Role.Admin
                    },
                    new User()
                    {
                        Id = 2,
                        Name = "Moderator",
                        Password = HashPasswordHelper.HashPassowrd("654321"),
                        Role = Role.Moderator
                    }
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x => x.Cart)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Dish>(builder =>
            {
                builder.ToTable("Dishes").HasKey(x => x.Id);
                builder.HasData(new Dish[]
                {
        new Dish
        {
            Id = 1,
            Name = "Bread",
            Description = new string('A', 50),
            DateCreate = DateTime.Now,
            Price = 2500,
            Category = Category.Appetizers, // Вказати відповідну категорію
        },

        new Dish
        {
            Id = 2,
            Name = "Wine",
            Description = new string('A', 50),
            DateCreate = DateTime.Now,
            Category = Category.Beverages, // Вказати відповідну категорію
        },

        new Dish
        {
            Id = 3,
            Name = "Pizza \"Paperoni\" ",
            Description = new string('A', 50),
            DateCreate = DateTime.Now,
            Price = 3000,
            Category = Category.Pizza, // Вказати відповідну категорію
        },
        new Dish
        {
            Id = 4,
            Name = "Beer \"Corona\"",
            Description = new string('A', 50),
            DateCreate = DateTime.Now,
            Price = 120,
            Category = Category.AlcoholicBeverages, // Вказати відповідну категорію
        },
        new Dish
        {
            Id = 5,
            Name = "Mongolian Beef",
            Description = new string('A', 50),
            DateCreate = DateTime.Now,
            Price = 3000,
            Category = Category.MainCourses, // Вказати відповідну категорію
        }
                });
            });


            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Address).IsRequired(false); 

                builder.HasData(new Profile()
                {
                    Id = 1,
                    UserId = 1,
                    Address = "123 Main Street" 
                });
            });

            modelBuilder.Entity<Cart>(builder =>
            {
                builder.ToTable("Carts").HasKey(x => x.Id);
                builder.HasData(new Cart()
                {
                    Id = 1,
                    UserId = 1
                });

            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Id);

                builder.HasOne(r => r.Cart).WithMany(t => t.Orders)
                    .HasForeignKey(r => r.CartId);
            });

            modelBuilder.Entity<DishPhoto>(builder =>
            {
                builder.ToTable("Photos").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.ImageData).IsRequired();

                string relativeImagePath1 = "img/DishPhotos/PizzaPaperoni.jpg";
                string relativeImagePath2 = "img/DishPhotos/bread.jpg";
                string relativeImagePath3 = "img/DishPhotos/WineTraverseBay.jpg";
                string relativeImagePath4 = "img/DishPhotos/BeerCorona.jpg";
                string relativeImagePath5 = "img/DishPhotos/MongolianBeef.jpg";

                byte[] imageData1 = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath1));
                byte[] imageData2 = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath2));
                byte[] imageData3 = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath3));
                byte[] imageData4 = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath4));
                byte[] imageData5 = System.IO.File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath5));

                builder.HasData(new DishPhoto[]
                {
                    new DishPhoto
                    {
                        Id = 1,
                        DishId = 3,
                        ImageData = imageData1,
                    },
                    new DishPhoto
                    {
                        Id = 2,
                        DishId = 1,
                        ImageData = imageData2,
                    },
                    new DishPhoto
                    {
                        Id = 3,
                        DishId = 2,
                        ImageData = imageData3,
                    },
                    new DishPhoto
                    {
                        Id = 4,
                        DishId = 4,
                        ImageData = imageData4,
                    },
                    new DishPhoto
                    {
                        Id = 5,
                        DishId = 5,
                        ImageData = imageData5,
                    },
                });
            });


        }
    }
}
