using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaraunt.Domain.Entity
{
    public class Profile
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
