using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.Exceptions;
using MoviesCatalog.Models;
using MoviesCatalog.Models.DTO;
using MoviesCatalog.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MoviesCatalog.Services
{
    public class AuthService : IAuthService
    {
        private readonly Context _context;
        public AuthService(Context context)
        {
            _context = context;
        }

        public async Task<JsonResult> Token(UserLoginCredentials credentials)
        {
            ClaimsIdentity? identity = await GetIdentity(credentials.Email, credentials.Password);
            if (identity is null)
            {
                throw new BadHttpRequestException("Invalid Email or password");
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: JwtConfigurations.Issuer,
                audience: JwtConfigurations.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.AddMinutes(JwtConfigurations.Lifetime),
                signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var enctoken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = enctoken
            };

            return new JsonResult(response);
        }

        public async Task Logout(string token)
        {
            await _context.Blacklist.AddAsync(new BlacklistedToken
            {
                Value = token
            });
            await _context.SaveChangesAsync();
        }

        public async Task Register(UserRegistrationDto user)
        {
            if (await _context.Users.AnyAsync(x => x.Email == user.Email))
            {
                throw new BadHttpRequestException("Email is already taken");
            }
            else if (await _context.Users.AnyAsync(x => x.Email == user.Username))
            {
                throw new BadHttpRequestException("Username is already taken");
            }

            await _context.Users.AddAsync(new User
            {
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Password = EncodePassword(user.Password),
                Birthdate = user.Birthdate,
                Gender = user.Gender
            });
            await _context.SaveChangesAsync();
        }

        private async Task<ClaimsIdentity?> GetIdentity(string email, string password)
        {
            var hashedPassword = EncodePassword(password);
            var user = await _context.Users.Where(user => user.Email == email && user.Password == hashedPassword).ToListAsync();
            if (user.IsNullOrEmpty())
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim("id", user[0].Id.ToString())
            };

            return new ClaimsIdentity(claims, "Token");
        }

        private string EncodePassword(string password) =>
            Convert.ToHexString(
                SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(password))
                );

    }
}
