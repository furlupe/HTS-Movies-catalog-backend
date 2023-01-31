using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.Models;
using System.Text;

namespace MoviesCatalog.Utils
{
    public class ExtendedAuthRequirementHandler : AuthorizationHandler<ExtendedAuthRequirement>
    {
        private readonly Context _dbContext;
        private readonly IHttpContextAccessor _httpContext;

        public ExtendedAuthRequirementHandler(Context dbContext, IHttpContextAccessor httpContext) { 
            _dbContext = dbContext; 
            _httpContext = httpContext;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ExtendedAuthRequirement requirement)
        {
            if (context.User.Claims.IsNullOrEmpty()) { return; }

            var token = _httpContext.HttpContext.Request.Headers.Authorization.ToString();

            if (! await _dbContext.Blacklist.AnyAsync(t => t.Value == token))
            {
                context.Succeed(requirement);
                return;
            }

            var Response = _httpContext.HttpContext.Response;
            var msg = Encoding.UTF8.GetBytes("Unauthorized");
            Response.OnStarting(async () =>
            {
                Response.StatusCode = 401;
                await Response.Body.WriteAsync(msg, 0, msg.Length);
            });

        }
    }
}
