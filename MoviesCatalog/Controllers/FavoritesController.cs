using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;
using MoviesCatalog.Utils;

namespace MoviesCatalog.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService _favoritesService;
        public FavoritesController(IFavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }

        [HttpGet]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<FavoriteMoviesDto> GetFavorites()
        {
            return await _favoritesService.GetFavorites(
                JwtParser.GetId(Request.Headers.Authorization)
                );
        }

        [HttpPost("{id}/add")]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task AddFavoriteMovie([BindRequired] Guid id)
        {
            await _favoritesService.AddFavoriteMovie(
                JwtParser.GetId(Request.Headers.Authorization), 
                id
                );
        }
    }
}
