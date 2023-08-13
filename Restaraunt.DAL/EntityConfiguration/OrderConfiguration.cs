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

            builder.HasOne(r => r.Cart)
                .WithMany(t => t.Orders)
                .HasForeignKey(r => r.CartId);
        }
    }
}
