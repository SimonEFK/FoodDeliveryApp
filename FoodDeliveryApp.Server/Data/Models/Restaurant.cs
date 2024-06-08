namespace FoodDeliveryApp.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Restaurant
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<Menu> Menus { get; set; } = new List<Menu>();

    }
}
