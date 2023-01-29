using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IAuthService
    {
        Task Register(UserRegistrationDto user);
        Task<JsonResult> Token(UserLoginCredentials credentials);
        Task Logout(string request);
    }
}
