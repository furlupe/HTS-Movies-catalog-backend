using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Exceptions;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;

namespace MoviesCatalog.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult?> Register(UserRegistrationDto user)
        {
            try
            {
                await _authService.Register(user);
                return await _authService.Token(new UserLoginCredentials { Email = user.Email, Password = user.Password });
            }
            catch(BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Token(UserLoginCredentials credentials)
        {
            try
            {
                return await _authService.Token(credentials);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Policy = "NotBlacklisted")]
        [HttpPost("logout")]
        public async Task Logout() => 
            await _authService.Logout(Request.Headers.Authorization);
    }
}
