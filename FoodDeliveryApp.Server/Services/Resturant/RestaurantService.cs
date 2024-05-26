namespace FoodDeliveryApp.Server.Services.Resturant
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Data.Models;
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.MenuItem;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public RestaurantService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<string> CreateRestaurant(string userId, RestaurantCreateRequestModel model)
        {
            var newRestaurant = new Restaurant()
            {
                UserId = userId,
                Name = model.Name.Trim(),
                ImageUrl = model.ImageUrl?.Trim(),
            };

            newRestaurant.Menus.Add(new Menu());
            await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return newRestaurant.Id;
        }

        [HttpGet("api/restaurants/{id?}")]
        public async Task<ICollection<TModel>> GetRestaurants<TModel>(string? id = null)
        {
            var restaurants = await _context
                .Restaurants
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return restaurants;
        }

        public async Task AddItemToRestaurant(string userId, string restaurantId, MenuItemCreateRequestModel itemModel)
        {
            var menu = await _context.Menus
                .Where(x => x.RestaurantId == restaurantId && x.Restaurant.UserId == userId).FirstOrDefaultAsync();

            if (menu == null)
            {
                //TODO
            }

            var item = new Item
            {
                Name = itemModel.Name.Trim(),
                Price = itemModel.Price,
                Description = itemModel.Description,
                //CategoryId = itemModel.CategoryId,
                ImageUrl = itemModel.ImageUrl
            };
            menu.MenuItems.Add(new MenuItem
            {
                Item = item,
            });
            await _context.SaveChangesAsync();
        }



    }
}
