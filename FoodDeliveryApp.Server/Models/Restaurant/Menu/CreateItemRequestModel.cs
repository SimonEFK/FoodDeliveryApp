namespace FoodDeliveryApp.Server.Models.Restaurant.Menu
{
    public class CreateItemRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal? Price { get; set; }

        public ICollection<int> Categories { get; set; } = new HashSet<int>();
    }
}
