using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Exceptions;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;
using MoviesCatalog.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace MoviesCatalog.Controllers
{
    [Route("api/account/profile")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Returns user's info
        /// </summary>
        /// <response code="401">Unauthorized</response>
        [HttpGet]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<UserProfileDto> Profile()
        {
            return await _userService.GetProfile(
                JwtParser.GetId(Request.Headers.Authorization)
                );
        }

        /// <summary>
        /// Changes user's info
        /// </summary>
        /// <response code="401">Unauthorized</response>
        /// <response code="400">Bad request</response>
        /// <response code="403">Forbidden</response>
        [HttpPut]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> Profile(UserProfileDto profile)
        {
            try
            {
                await _userService.UpdateProfile(
                    profile, 
                    JwtParser.GetId(Request.Headers.Authorization)
                    );
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (ForbiddenException)
            {
                return Forbid();
            }

            return Ok();
        }
    }
}
