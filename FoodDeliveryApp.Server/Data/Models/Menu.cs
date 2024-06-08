namespace FoodDeliveryApp.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Menu
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}