using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
