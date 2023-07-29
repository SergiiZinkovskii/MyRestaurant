using Microsoft.EntityFrameworkCore;
using Restaraunt.Domain.Entity;
using Restaraunt.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Restaraunt.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

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
                        Password = "123456",
                        Role = Role.Admin
                    },
                    new User()
                    {
                        Id = 2,
                        Name = "Moderator",
                        Password = "654321",
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


            });

            modelBuilder.Entity<Profile>(builder =>
            {
                builder.ToTable("Profiles").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();


                builder.HasData(new Profile()
                {
                    Id = 1,
                    UserId = 1
                });
            });

            modelBuilder.Entity<Cart>(builder =>
            {
                builder.ToTable("Carts").HasKey(x => x.Id);

            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Id);

                builder.HasOne(r => r.Cart).WithMany(t => t.Orders)
                    .HasForeignKey(r => r.BasketId);
            });

            modelBuilder.Entity<DishPhoto>(builder =>
            {
                builder.ToTable("Photos").HasKey(x => x.Id);

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.ImageData).IsRequired();

                builder.HasOne(x => x.Dish)
                    .WithMany(x => x.DishPhotos)
                    .HasForeignKey(x => x.DishId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }
    }
}
