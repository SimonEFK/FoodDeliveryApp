namespace FoodDeliveryApp.Server.Services.Authentication
{
    using FoodDeliveryApp.Server.Data.Models;

    public interface IAuthenticateUserService
    {
        string AuthenticateUser(ApplicationUser applicationUser);
    }
}