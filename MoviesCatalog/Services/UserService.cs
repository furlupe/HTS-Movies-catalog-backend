using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public class UserService : IUserService
    {
        public Task<UserProfileDto> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfile(UserProfileDto profile)
        {
            throw new NotImplementedException();
        }
    }
}
