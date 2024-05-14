namespace FoodDeliveryApp.Server.Data
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string Token { get; set; }
    }
}
