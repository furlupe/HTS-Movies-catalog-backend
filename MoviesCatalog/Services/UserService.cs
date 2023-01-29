using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Models;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        public UserService(Context context)
        {
            _context = context;
        }
        public async Task<UserProfileDto> GetProfile(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            return new UserProfileDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Avatar = user.Avatar,
                Name = user.Name,
                Birthdate= user.Birthdate,
                Gender = user.Gender
            };
        }

        public Task UpdateProfile(UserProfileDto profile)
        {
            throw new NotImplementedException();
        }
    }
}
