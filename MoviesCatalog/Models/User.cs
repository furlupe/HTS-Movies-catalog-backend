using MoviesCatalog.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string? Avatar { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Movie> Favorites { get; set; }
    }
}
