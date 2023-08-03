using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Enter name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Pasword")]
        [MinLength(6, ErrorMessage = "The password must consist of more than five characters")]
        public string NewPassword { get; set; }
    }
}
