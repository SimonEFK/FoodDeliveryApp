namespace FoodDeliveryApp.Server.Services.Authentication
{
    using FoodDeliveryApp.Server.Data;

    public interface IAuthenticateUserService
    {
        string AuthenticateUser(ApplicationUser applicationUser);
    }
}