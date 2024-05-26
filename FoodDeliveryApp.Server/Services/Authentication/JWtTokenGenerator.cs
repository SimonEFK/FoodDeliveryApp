namespace FoodDeliveryApp.Server.Services.Authentication
{
    using FoodDeliveryApp.Server.AppSettings;
    using FoodDeliveryApp.Server.Data.Models;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class JWtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IOptions<JwtSettings> jwtSettings;


        public JWtTokenGenerator(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings;

        }

        public string GenerateToken(ApplicationUser applicationUser)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtSettings.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,applicationUser.UserName.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,applicationUser.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            applicationUser.Token = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}
