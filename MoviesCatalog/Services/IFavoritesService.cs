using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IFavoritesService
    {
        Task<FavoriteMoviesDto> GetFavorites(Guid userId);
        Task AddFavoriteMovie(Guid userId, Guid movieId);
        Task RemoveFavoriteMovie(Guid userId, Guid movieId);
    }
}
