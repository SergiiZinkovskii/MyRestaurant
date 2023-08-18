namespace Restaurant.Domain.Entity
{
    public class Comment
    {
        public long Id { get; set; }
        public long DishId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
