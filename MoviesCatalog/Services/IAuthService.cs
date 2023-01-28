using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IAuthService
    {
        Task Register(UserRegistrationDto user);
        Task Login(UserLoginCredentials credentials);
        Task Logout();
    }
}
