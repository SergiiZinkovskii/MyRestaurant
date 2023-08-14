using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entity;

namespace Restaurant.DAL.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Dish)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.DishId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
