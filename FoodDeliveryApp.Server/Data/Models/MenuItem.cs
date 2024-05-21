namespace FoodDeliveryApp.Server.Data.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        public Menu Menu { get; set; }

        public string MenuId { get; set; }

        public Item Item { get; set; }

        public int ItemId { get; set; }
    }
}