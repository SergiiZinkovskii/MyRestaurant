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
            builder.HasMany(o => o.Orders).WithMany(d => d.Dishes);


        }
    }
}