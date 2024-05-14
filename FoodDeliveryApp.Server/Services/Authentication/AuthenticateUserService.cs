namespace FoodDeliveryApp.Server.Services.Authentication
{
    using FoodDeliveryApp.Server.AppSettings;
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Models.Account;
    using Microsoft.AspNetCore.Identity.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class AuthenticateUserService : IAuthenticateUserService
    {
        private readonly IOptions<JwtSettings> jwtSettings;
        

        public AuthenticateUserService(IOptions<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings;
            
        }

        public string AuthenticateUser(ApplicationUser applicationUser)
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
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            applicationUser.Token = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}
