using MoviesCatalog.Models;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public class AuthService : IAuthService
    {
        private readonly Context _context;
        public AuthService(Context context)
        {
            _context = context;
        }

        public Task Login(UserLoginCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task Register(UserRegistrationDto user)
        {
            await _context.Users.AddAsync(new User
            {
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                Birthdate = user.Birthdate,
                Gender = user.Gender
            });
            await _context.SaveChangesAsync();
        }
    }
}
