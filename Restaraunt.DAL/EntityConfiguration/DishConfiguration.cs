using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using System;

namespace Restaurant.DAL.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dishes").HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.DateCreate).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Category).IsRequired();

            builder.HasData(new Dish[]
            {
                new Dish
                {
                    Id = 1,
                    Name = "Bread",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Price = 2500,
                    Category = Category.Appetizers
                },
                new Dish
                {
                    Id = 2,
                    Name = "Wine",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Category = Category.Beverages
                },
                new Dish
                {
                    Id = 3,
                    Name = "Pizza \"Paperoni\"",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Price = 3000,
                    Category = Category.Pizza
                },
                new Dish
                {
                    Id = 4,
                    Name = "Beer \"Corona\"",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Price = 120,
                    Category = Category.AlcoholicBeverages
                },
                new Dish
                {
                    Id = 5,
                    Name = "Mongolian Beef",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Price = 3000,
                    Category = Category.MainCourses
                }
                
            });
        }
    }
}
