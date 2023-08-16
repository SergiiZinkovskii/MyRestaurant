using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Restaurant.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders").HasKey(x => x.Id);

            builder.HasOne(o => o.Cart)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CartId);

            builder.HasMany(o => o.Dishes)
                .WithMany(d => d.Orders);

            // Ініціалізація тестових замовлень
            var orders = new List<Order>();

            for (int i = 1; i <= 20; i++)
            {
                orders.Add(new Order
                {
                    Id = i,
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

            builder.HasData(orders);
        }
    }
}
