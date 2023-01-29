using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Services;
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


        [HttpGet]
        [Authorize]
        public async Task<UserProfileDto> Profile()
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers.Authorization);
            var id = new Guid(
                    new JwtSecurityTokenHandler()
                    .ReadJwtToken(header.Parameter)
                    .Claims.First(claim => claim.Type == "id").Value
                );

            return await _userService.GetProfile(id);
        }

        [HttpPut]
        [Authorize]
        public async Task Profile(UserProfileDto profile)
        {
            throw new NotImplementedException();
        }
    }
}
