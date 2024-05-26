namespace FoodDeliveryApp.Server.Services.Resturant
{
    using FoodDeliveryApp.Server.Data.Models;
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.MenuItem;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRestaurantService
    {
        Task AddItemToRestaurant(string userId, string restaurantId, MenuItemCreateRequestModel itemModel);
        Task<string> CreateRestaurant(string userId, RestaurantCreateRequestModel model);        
        Task<ICollection<TModel>> GetRestaurants<TModel>(string? id = null);
    }
}
