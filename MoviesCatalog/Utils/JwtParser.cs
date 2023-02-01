using Azure.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace MoviesCatalog.Utils
{
    public class JwtParser
    {
        public static Guid GetId(string token)
        {
            var header = AuthenticationHeaderValue.Parse(token);
            return new Guid(
                new JwtSecurityTokenHandler()
                    .ReadJwtToken(header.Parameter)
                    .Claims.First(claim => claim.Type == "id").Value
                );
        }
    }
}
