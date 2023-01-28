using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MoviesCatalog.Utils
{
    public class JwtConfigurations
    {
        public const string Issuer = "Furlupe";
        public const string Audience = "JwtClient";
        private const string Key = "FortniteHambugerSussyBalls445";
        public const int Lifetime = 30;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
