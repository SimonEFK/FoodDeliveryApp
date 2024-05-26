namespace FoodDeliveryApp.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        public Item Item { get; set; }

        public int ItemId { get; set; }

        public Menu Menu { get; set; }

        public string MenuId { get; set; }

    }
}