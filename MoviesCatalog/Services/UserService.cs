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
            var user = await _context.Users.SingleAsync(u => u.Id == id);
            return new UserProfileDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Avatar = user.Avatar,
                Name = user.Name,
                Birthdate = user.Birthdate,
                Gender = user.Gender
            };
        }

        public async Task UpdateProfile(UserProfileDto profile, Guid id)
        {
            if (profile.Id != id)
            {
                throw new ForbiddenException();
            }
            else if (await _context.Users.AnyAsync(user => user.Email == profile.Email && user.Id != profile.Id))
            {
                throw new BadHttpRequestException("Email is already taken");
            }
            else if (await _context.Users.AnyAsync(user => user.Username == profile.Username && user.Id != profile.Id))
            {
                throw new BadHttpRequestException("Username is already taken");
            }

            _context.Entry(await _context.Users.SingleAsync(x => x.Id == profile.Id))
                .CurrentValues.SetValues(profile);
            await _context.SaveChangesAsync();
        }
    }
}
