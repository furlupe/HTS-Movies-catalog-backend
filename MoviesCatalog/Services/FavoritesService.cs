using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Models;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public class FavoritesService : IFavoritesService
    {
        private readonly Context _context;
        public FavoritesService(Context context)
        {
            _context = context;
        }
        public Task AddFavoriteMovie(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteMoviesDto> GetFavorites(Guid userId)
        {
            var movies = new List<MovieShortDto>();
            var selectedMovies = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

            if(selectedMovies.Favorites is null) {
                return new FavoriteMoviesDto() 
                { 
                    Movies = movies
                };
            }

            foreach(var movie in selectedMovies.Favorites)
            {
                var genres = new List<GenreDto>();
                foreach(var genre in movie.Genres)
                {
                    genres.Add(new GenreDto()
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    });
                }

                var reviews = new List<ReviewShortDto>();
                if(movie.Reviews is not null)
                {
                    foreach(var review in movie.Reviews)
                    {
                        reviews.Add(new ReviewShortDto()
                        {
                            Id = review.Id,
                            Rating = review.Rating
                        });
                    }
                }

                movies.Add(new MovieShortDto()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Poster = movie.Poster,
                    Year = movie.Year,
                    Country = movie.Country,
                    Genres = genres,
                    Reviews = reviews
                });
            }
            
            return new FavoriteMoviesDto()
            {
                Movies = movies
            };
        }

        public Task RemoveFavoriteMovie(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
