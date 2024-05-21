namespace FoodDeliveryApp.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Category? Parent { get; set; }

        public int? ParentId { get; set; }

        public ICollection<Item> Items { get; set; } = new HashSet<Item>();

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}