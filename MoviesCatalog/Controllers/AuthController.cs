using Microsoft.AspNetCore.Mvc;

namespace MoviesCatalog.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public string Register()
        {
            return "Registration success";
        }
        [HttpPost]
        public string Login()
        {
            return "Logged in";
        }
        [HttpPost]
        public string Logout()
        {
            return "Logged out";
        }
    }
}
