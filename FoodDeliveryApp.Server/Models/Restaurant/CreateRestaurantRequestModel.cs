namespace FoodDeliveryApp.Server.Models.Restaurant
{
    public class CreateRestaurantRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string? ImageUrl { get; set; }

    }
}