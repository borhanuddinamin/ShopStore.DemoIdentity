using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopStore.Web.Securities.Token
{
    public class TokenService:ITokenService
    {

        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public async Task <String>GetJwtToken(IList<Claim> claims)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var Key = Encoding.ASCII.GetBytes(configuration["JWT:Key"]);

            var TokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                         SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(TokenDiscriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}


