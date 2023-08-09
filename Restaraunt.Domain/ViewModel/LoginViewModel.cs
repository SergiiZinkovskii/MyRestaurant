using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your name")]
        [MaxLength(20, ErrorMessage = "The name must be less than 20 characters")]
        [MinLength(2, ErrorMessage = "The name must consist of more than one character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
