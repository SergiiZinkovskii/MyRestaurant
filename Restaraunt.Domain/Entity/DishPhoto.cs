using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entity
{
    public class DishPhoto
    {
        public long Id { get; set; }
        public byte[] ImageData { get; set; }
        public long DishId { get; set; }
        public virtual Dish? Dish { get; set; }
    }
}
