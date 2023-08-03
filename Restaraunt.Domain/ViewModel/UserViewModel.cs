using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Enter Role")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Enter Login")]
        [Display(Name = "Login")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "password")]
        public string Password { get; set; }
    }
}
