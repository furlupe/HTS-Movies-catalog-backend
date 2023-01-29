using Microsoft.AspNetCore.Mvc;

namespace MoviesCatalog.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public string Register()
        {
            return "Registration success";
        }
        [HttpPost("login")]
        public string Login()
        {
            return "Logged in";
        }
        [HttpPost("logout")]
        public string Logout()
        {
            return "Logged out";
        }
    }
}
