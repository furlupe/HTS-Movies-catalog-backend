using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Models.DTO
{
    public class UserLoginCredentials
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
