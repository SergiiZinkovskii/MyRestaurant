using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class DishViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreate { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<byte[]> Photos { get; set; }
    }
}
