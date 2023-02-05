using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models.DTO
{
    public class NewReviewDto
    {
        [Required]
        public string Text { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        public bool IsAnonymous { get; set; }
    }
}
