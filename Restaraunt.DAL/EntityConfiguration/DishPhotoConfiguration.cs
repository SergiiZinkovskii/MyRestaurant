using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entity;
using System;
using System.IO;

namespace Restaurant.DAL.Configurations
{
    public class DishPhotoConfiguration : IEntityTypeConfiguration<DishPhoto>
    {
        public void Configure(EntityTypeBuilder<DishPhoto> builder)
        {
            builder.ToTable("Photos").HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ImageData).IsRequired();

        }
    }
}
