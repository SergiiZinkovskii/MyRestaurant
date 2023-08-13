using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entity
{
    public class Order
    {
        public long Id { get; set; }
        public long? DishId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Post { get; set; }
        public string Payment { get; set; }
        public string Comments { get; set; }
        public long? CartId { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
