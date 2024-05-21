namespace FoodDeliveryApp.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string? Token { get; set; }
    }
}
