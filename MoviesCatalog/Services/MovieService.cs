using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Exceptions;
using MoviesCatalog.Models;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public class MovieService : IMovieService
    {
        private readonly Context _context;
        private const int PAGE_SIZE = 3;
        public MovieService(Context context)
        {
            _context = context;
        }
        public async Task<MoviesPagedListDto> GetMoviesPage(int page)
        {
            if (page < 1)
            {
                throw new BadRequestException($"Wrong page No.");
            }

            var pageCount = (_context.Movies.Count() / PAGE_SIZE) + Convert.ToInt32(_context.Movies.Count() % PAGE_SIZE > 0);
            if (page > pageCount)
            {
                throw new BadRequestException($"Page No.{page} is greater than amount of pages");
            }

            var selectedMovies = await _context.Movies
                .Skip((page - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE).Include(m => m.Reviews).ToListAsync();

            var movies = new List<MovieShortDto>();
            foreach(var movie in selectedMovies)
            {
                var selectedGenres = await _context.MovieGenres
                    .Where(g => g.MovieId == movie.Id)
                    .Include(g => g.Genre).ToListAsync();

                var genres = new List<GenreDto>();
                foreach(var genre in selectedGenres) {
                    genres.Add(new GenreDto()
                    {
                        Id = genre.GenreId,
                        Name = genre.Genre.Name
                    });
                }

                var reviews = new List<ReviewShortDto>();
                if(movie.Reviews is not null)
                {
                    foreach (var review in movie.Reviews)
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

            var pageInfo = new PageDto()
            {
                Size = PAGE_SIZE,
                Count = pageCount,
                Current = page
            };

            return new MoviesPagedListDto()
            {
                Movies = movies,
                PageInfo = pageInfo
            };
        }
    }
}
