using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesCatalog.Exceptions;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{page}")]
        public async Task<ActionResult<MoviesPagedListDto>> GetMoviesList([BindRequired, Range(1, int.MaxValue)] int page)
        {
            try
            {
                return await _movieService.GetMoviesPage(page);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<MovieDetailsDto>> GetMovieDetails([BindRequired] Guid id)
        {
            try
            {
                return await _movieService.GetMovieDetails(id);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
