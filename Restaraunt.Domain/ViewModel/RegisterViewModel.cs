using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        [MaxLength(20, ErrorMessage = "The name must be less than 20 characters")]
        [MinLength(2, ErrorMessage = "The name must consist of more than one character")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a password")]
        [MinLength(6, ErrorMessage = "The password must consist of at least 6 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords areeredo not match")]
        public string PasswordConfirm { get; set; }
    }
}
