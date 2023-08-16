using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entity
{
    public class Cart
    {
        public long Id { get; set; }

        public User User { get; set; }

        public long UserId { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
