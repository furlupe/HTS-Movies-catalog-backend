using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesCatalog.Models
{
    [PrimaryKey(nameof(UserId), nameof(MovieId))]
    public class FavoriteMovie
    {
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
}
