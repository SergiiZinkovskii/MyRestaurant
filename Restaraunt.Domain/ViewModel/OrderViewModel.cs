using Restaurant.Domain.Entity;

namespace Restaurant.Domain.ViewModel
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public string DishName { get; set; }
        public string Category { get; set; }
        public DishPhoto Photo { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DateCreate { get; set; }
        public int Phone { get; set; }
        public decimal Price { get; set; }
        public string Post { get; set; }
        public string Payment { get; set; }
        public string Comments { get; set; }
        public int Quantity { get; set; }
    }
}
