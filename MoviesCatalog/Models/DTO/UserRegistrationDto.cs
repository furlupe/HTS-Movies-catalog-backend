using MoviesCatalog.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models.DTO
{
    public class UserRegistrationDto
    {
        [MinLength(4, ErrorMessage = "Username too short")]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
