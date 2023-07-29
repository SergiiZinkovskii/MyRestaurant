using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Restaurant.Domain.Enum
{
    public enum Role
    {
        [Display(Name = "user")]
        User = 0,
        [Display(Name = "moderator")]
        Moderator = 1,
        [Display(Name = "admin")]
        Admin = 2,
    }
}
