using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Models;
using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public class ReviewService : IReviewService
    {
        private readonly Context _context;
        public ReviewService(Context context)
        {
            _context = context;
        }

        public async Task AddReview(Guid userId, Guid movieId, NewReviewDto review)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == movieId);
            if (movie is null) 
            {
                throw new BadHttpRequestException($"Movie w/ id = {movieId} does not exist");
            }

            var user = await _context.Users.SingleAsync(u => u.Id == userId);
            var newReview = new Review()
            {
                User = user,
                Movie = movie,
                Text = review.Text,
                Rating = review.Rating,
                IsAnonymous = review.IsAnonymous,
                CreationDateTime = DateTime.UtcNow
            };

            await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReview(Guid userId, Guid reviewId, NewReviewDto review)
        {
            if(await _context.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId && r.UserId == userId) is null)
            {
                throw new BadHttpRequestException("", StatusCodes.Status403Forbidden);
            }
            _context.Entry(await _context.Reviews.SingleAsync(x => x.Id == reviewId))
                .CurrentValues.SetValues(review);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveReview(Guid userId, Guid reviewId)
        {
            var review = await _context.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId && r.UserId == userId);
            if (review is null)
            {
                throw new BadHttpRequestException("", StatusCodes.Status403Forbidden);
            }

            var movie = await _context.Movies.SingleAsync(m => m.Id == review.MovieId);
            movie.Reviews.Remove(review);

            await _context.SaveChangesAsync();
        }
    }
}
