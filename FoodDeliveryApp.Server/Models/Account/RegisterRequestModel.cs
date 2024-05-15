namespace FoodDeliveryApp.Server.Models.Account
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequestModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
