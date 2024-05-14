namespace FoodDeliveryApp.Server.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequestModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
