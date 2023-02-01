using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IFavoritesService
    {
        Task<FavoriteMoviesDto> GetFavorites(Guid userId);
        Task AddFavoriteMovie(Guid userId);
        Task RemoveFavoriteMovie(Guid userId);
    }
}
