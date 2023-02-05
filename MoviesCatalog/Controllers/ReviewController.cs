using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;
using MoviesCatalog.Utils;

namespace MoviesCatalog.Controllers
{
    [Route("api/movie/review")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> AddReview([BindRequired] Guid movieId, NewReviewDto review)
        {
            try
            {
                await _reviewService.AddReview(
                    JwtParser.GetId(Request.Headers.Authorization),
                    movieId, 
                    review
                    );
            }
            catch(BadHttpRequestException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> UpdateReview([BindRequired] Guid id, NewReviewDto review)
        {
            try
            {
                await _reviewService.UpdateReview(
                    JwtParser.GetId(Request.Headers.Authorization),
                    id,
                    review
                    );
            }
            catch (BadHttpRequestException)
            {
                return Forbid();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> RemoveReview([BindRequired] Guid id)
        {
            try
            {
                await _reviewService.RemoveReview(
                    JwtParser.GetId(Request.Headers.Authorization),
                    id
                    );
            } 
            catch(BadHttpRequestException)
            {
                return Forbid();
            }

            return Ok();
        }

    }
}
