namespace FoodDeliveryApp.Server.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string MenuId { get; set; }

        public Menu Menu { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}