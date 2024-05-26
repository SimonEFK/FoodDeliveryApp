﻿namespace FoodDeliveryApp.Server.Data.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public Category? Category { get; set; }

        public int? CategoryId { get; set; }

        public ICollection<MenuItem> Menus { get; set; }
    }
}