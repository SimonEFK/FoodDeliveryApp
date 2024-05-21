﻿namespace FoodDeliveryApp.Server.Data.Models
{
    public class Menu
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Restaurant Restaurant { get; set; }

        public string RestaurantId { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
    }
}