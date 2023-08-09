using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, 100, ErrorMessage = "The quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Display(Name = "Date of creation")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Delivery address")]
        [Required(ErrorMessage = "Enter the delivery address")]
        [MinLength(5, ErrorMessage = "The address must contain more than 5 characters")]
        [MaxLength(200, ErrorMessage = "The address must be less than 200 characters")]
        public string Address { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter a name")]
        [MaxLength(20, ErrorMessage = "The name must be less than 20 characters")]
        [MinLength(2, ErrorMessage = "The name must consist of more than 1 character")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [MaxLength(50, ErrorMessage = "The last name must be less than 50 characters")]
        [MinLength(2, ErrorMessage = "The last name must be less than 50 characters")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Enter a phone number")]
        public int Phone { get; set; }

        [Display(Name = "Postal operator")]
        [Required(ErrorMessage = "Choose a postal operator")]
        public string Post { get; set; }

        [Display(Name = "Form of payment")]
        [Required(ErrorMessage = "Choose a payment method")]
        public string Payment { get; set; }

        [Display(Name = "Comments to the order")]

        public string Comments { get; set; }

        public long DishId { get; set; }

        public string Login { get; set; }
    }
}
