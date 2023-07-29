﻿using Restaraunt.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaraunt.Domain.Entity
{
    public class Dish
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public Category Category { get; set; }
        public ICollection<DishPhoto> DishPhotos { get; set; }
    }
}