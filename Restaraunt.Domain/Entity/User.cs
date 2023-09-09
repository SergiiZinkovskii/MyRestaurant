using Restaurant.Domain.Enum;

namespace Restaurant.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Cart Cart { get; set; }
        public DateTime DateOfBirth { get; set; }
        
    }
}
