using Microsoft.EntityFrameworkCore;
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
            var pageCount = (_context.Movies.Count() / PAGE_SIZE) + Convert.ToInt32(_context.Movies.Count() % PAGE_SIZE > 0);
            if (page > pageCount)
            {
                throw new BadHttpRequestException($"Page No. {page} is greater than amount of pages");
            }

            var selectedMovies = await _context.Movies
                .Skip((page - 1) * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .Include(m => m.Reviews).ToListAsync();

            var movies = new List<MovieShortDto>();
            foreach (var movie in selectedMovies)
            {

                var genres = new List<GenreDto>();
                if(movie.Genres is not null)
                {
                    foreach (var genre in movie.Genres)
                    {
                        genres.Add(new GenreDto()
                        {
                            Id = genre.Id,
                            Name = genre.Name
                        });
                    }
                }

                var reviews = new List<ReviewShortDto>();
                if (movie.Reviews is not null)
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

        public async Task<MovieDetailsDto> GetMovieDetails(Guid id)
        {
            var movie = await _context.Movies
                .Include(m => m.Genres)
                .Include(m => m.Reviews)
                    .ThenInclude(r => r.User)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (movie is null)
            {
                throw new BadHttpRequestException($"Movie w/ id = {id} does not exist!");
            }

            var genres = new List<GenreDto>();
            if(movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    genres.Add(new GenreDto()
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    });
                }
            }

            var reviews = new List<ReviewDto>();
            if (movie.Reviews is not null)
            {
                foreach (var review in movie.Reviews)
                {
                    reviews.Add(new ReviewDto()
                    {
                        Id = review.Id,
                        Rating = review.Rating,
                        Text = review.Text,
                        IsAnonymous = review.IsAnonymous,
                        CreationDateTime = review.CreationDateTime,
                        Author = new UserShortDto()
                        {
                            Id = review.UserId,
                            Username = review.User.Username,
                            Avatar = review.User.Avatar
                        }
                    });
                }
            }

            return new MovieDetailsDto()
            {
                Id = movie.Id,
                Name = movie.Name,
                Poster = movie.Poster,
                Year = movie.Year,
                Country = movie.Country,
                Genres = genres,
                Reviews = reviews,
                Time = movie.Time,
                Tagline = movie.Tagline,
                Description = movie.Description,
                Director = movie.Director,
                Budget = movie.Budget,
                Fees = movie.Fees,
                AgeLimit = movie.AgeLimit
            };
        }
    }
}
