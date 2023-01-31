using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IMovieService
    {
        Task<MoviesPagedListDto> GetMoviesPage(int page);
        // ... add detailed movie method after model's been made
    }
}
