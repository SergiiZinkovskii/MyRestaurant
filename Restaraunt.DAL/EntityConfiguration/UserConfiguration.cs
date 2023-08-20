using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using Restaurant.Domain.Extensions;

namespace Restaurant.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);

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
        }
    }
}
