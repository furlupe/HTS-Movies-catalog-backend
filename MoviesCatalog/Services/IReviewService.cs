using MoviesCatalog.Models.DTO;

namespace MoviesCatalog.Services
{
    public interface IReviewService
    {
        Task AddReview(Guid userId, Guid movieId, NewReviewDto review);
        Task UpdateReview(Guid userId, Guid reviewId, NewReviewDto review);
        Task RemoveReview(Guid userId, Guid reviewId);
    }
}
