using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesCatalog.Exceptions;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Controllers
{
    [Route("api/movies/{page}")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<MoviesPagedListDto>> GetMoviesList([BindRequired, Range(0, int.MaxValue)] int page)
        {
            try
            {
                return await _movieService.GetMoviesPage(page);
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
