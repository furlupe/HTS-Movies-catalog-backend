using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IMovieService
    {
        Task<MoviesPagedListDto> GetMoviesPage(int page);
        Task<MovieDetailsDto> GetMovieDetails(Guid id);
    }
}
