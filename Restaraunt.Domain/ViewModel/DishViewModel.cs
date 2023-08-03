using Restaurant.Domain.Entity;
using Restaurant.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ViewModel
{
    public class DishViewModel
    {

        public long Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Enter description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Enter price")]
        public decimal Price { get; set; }
        public string DateCreate { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Choose category")]
        public string Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<byte[]> Photos { get; set; }
    }
}
