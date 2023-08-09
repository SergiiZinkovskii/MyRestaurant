using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class ProfileViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Enter your age")]
        [Range(0, 150, ErrorMessage = "The age range should be from 0 to 150")]
        public byte Age { get; set; }

        [Required(ErrorMessage = "Enter your adress")]
        [MinLength(5, ErrorMessage = "The minimum length should be more than 5 characters")]
        [MaxLength(200, ErrorMessage = "The maximum length should be less than 200 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter your name")]
        public string UserName { get; set; }
    }
}
