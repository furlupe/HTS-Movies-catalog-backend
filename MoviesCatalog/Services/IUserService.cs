using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IUserService
    {
        Task<UserProfileDto> GetProfile(Guid id);
        Task UpdateProfile(UserProfileDto profile, Guid id);
    }
}
