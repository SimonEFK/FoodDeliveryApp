namespace FoodDeliveryApp.Server.Services.Authentication
{
    using FoodDeliveryApp.Server.Data.Models;

    public interface IJwtTokenGenerator
    {
        public string GenerateToken(ApplicationUser user);
    }
}
