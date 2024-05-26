namespace FoodDeliveryApp.Server.Models.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}