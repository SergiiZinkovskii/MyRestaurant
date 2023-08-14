using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entity;

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
        }
    }
}
