using MoviesCatalog.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models.DTO
{
    public class UserProfileDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Avatar { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
