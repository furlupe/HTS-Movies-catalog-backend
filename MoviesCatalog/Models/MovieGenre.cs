using Microsoft.EntityFrameworkCore;

namespace MoviesCatalog.Models
{
    [PrimaryKey(nameof(MovieId), nameof(GenreId))]
    public class MovieGenre
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
