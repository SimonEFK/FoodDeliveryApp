namespace FoodDeliveryApp.Server.Data.Models
{
    public class Restaurant
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Menu> Menus { get; set; } = new HashSet<Menu>();
    }
}
