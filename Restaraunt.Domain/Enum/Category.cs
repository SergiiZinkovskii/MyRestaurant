using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Enum
{
    public enum Category
    {
        [Display(Name = "Appetizers")]
        Appetizers = 0,
        [Display(Name = "Main Courses")]
        MainCourses = 1,
        [Display(Name = "Pasta")]
        Pasta = 2,
        [Display(Name = "Pizza")]
        Pizza = 3,
        [Display(Name = "Salads")]
        Salads = 4,
        [Display(Name = "Soups")]
        Soups = 5,
        [Display(Name = "Desserts")]
        Desserts = 6,
        [Display(Name = "Beverages")]
        Beverages = 7,
        [Display(Name = "Alcoholic Beverages")]
        AlcoholicBeverages = 8,
        [Display(Name = "Specials")]
        Specials = 9,
        [Display(Name = "Kids Menu")]
        KidsMenu = 10,
    }
}
