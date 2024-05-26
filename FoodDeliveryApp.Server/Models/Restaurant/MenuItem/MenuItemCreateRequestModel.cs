﻿namespace FoodDeliveryApp.Server.Models.Restaurant.MenuItem
{
    using System.ComponentModel.DataAnnotations;

    public class MenuItemCreateRequestModel
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; }

        public decimal? Price { get; set; }
    }
}
