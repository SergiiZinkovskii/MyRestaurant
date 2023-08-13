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

            string relativeImagePath1 = "img/DishPhotos/PizzaPaperoni.jpg";
            string relativeImagePath2 = "img/DishPhotos/bread.jpg";
            string relativeImagePath3 = "img/DishPhotos/WineTraverseBay.jpg";
            string relativeImagePath4 = "img/DishPhotos/BeerCorona.jpg";
            string relativeImagePath5 = "img/DishPhotos/MongolianBeef.jpg";

            byte[] imageData1 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath1));
            byte[] imageData2 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath2));
            byte[] imageData3 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath3));
            byte[] imageData4 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath4));
            byte[] imageData5 = File.ReadAllBytes(Path.Combine("wwwroot", relativeImagePath5));

            builder.HasData(new DishPhoto[]
            {
                new DishPhoto
                {
                    Id = 1,
                    DishId = 3,
                    ImageData = imageData1
                },
                new DishPhoto
                {
                    Id = 2,
                    DishId = 1,
                    ImageData = imageData2
                },
                new DishPhoto
                {
                    Id = 3,
                    DishId = 2,
                    ImageData = imageData3
                },
                new DishPhoto
                {
                    Id = 4,
                    DishId = 4,
                    ImageData = imageData4
                },
                new DishPhoto
                {
                    Id = 5,
                    DishId = 5,
                    ImageData = imageData5
                }
            });
        }
    }
}
