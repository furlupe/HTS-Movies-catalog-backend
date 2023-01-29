using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IAuthService
    {
        Task<bool> Register(UserRegistrationDto user);
        Task<IActionResult?> Token(UserLoginCredentials credentials);
        Task Logout(string request);
    }
}
