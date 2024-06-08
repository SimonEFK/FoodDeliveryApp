namespace FoodDeliveryApp.Server.Services.Resturant
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Data.Models;
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.Menu;
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

        public async Task<string> CreateRestaurant(CreateRestaurantRequestModel model, string userId)
        {
            var newRestaurant = new Restaurant
            {
                Name = model.Name.Trim(),
                Description = model.Description.Trim(),
                UserId = userId,
                ImageUrl = model.ImageUrl.Trim(),
            };
            newRestaurant.Menus.Add(new Menu());
            await _context.Restaurants.AddAsync(newRestaurant);
            await _context.SaveChangesAsync();
            return newRestaurant.Id;
        }

        public async Task AddItemToRestaurantMenu(CreateItemRequestModel model, string restaurantId, string applicationUserId)
        {
            var restaurant = _context.Restaurants
                .Where(x => x.UserId == applicationUserId && x.Id == restaurantId)
                .Select(x => x.Menus.FirstOrDefault())
                .FirstOrDefault();

            var newItem = new Item()
            {
                Name = model.Name.Trim(),
                ImageUrl = model.ImageUrl.Trim(),
                Price = model.Price.Value,
                Categories = model.Categories.Select(x => new Category
                {
                    Id = x
                }).ToList(),
            };


            restaurant.Items.Add(newItem);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetRestaurants<T>()
        {
            var result = await _context.Restaurants.ProjectTo<T>(mapper.ConfigurationProvider).ToListAsync();

            return result;
        }

    }
}
