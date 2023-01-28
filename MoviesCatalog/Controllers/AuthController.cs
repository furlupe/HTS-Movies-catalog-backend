using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if (!await _authService.Register(user))
            {
                return BadRequest(new { error = "User already exists" });
            }
            return await _authService.Token(new UserLoginCredentials { Email = user.Email, Password = user.Password });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Token(UserLoginCredentials credentials)
        {
            var token = await _authService.Token(credentials);

            if (token is null)
            {
                return BadRequest(new { error = "Invalid username or password" });
            }

            return token;
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task Logout() => 
            await _authService.Logout(Request.Headers.Authorization);
    }
}
