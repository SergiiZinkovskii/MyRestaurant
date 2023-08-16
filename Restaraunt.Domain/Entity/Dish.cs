using Restaurant.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entity
{
    public class Dish
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public DateTime DateCreate { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<DishPhoto> DishPhotos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
    }
}
