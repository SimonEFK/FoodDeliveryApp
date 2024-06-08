namespace FoodDeliveryApp.Server.Services.Resturant
{
    using FoodDeliveryApp.Server.Data.Models;
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.Menu;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRestaurantService
    {
        Task AddItemToRestaurantMenu(CreateItemRequestModel model, string restaurantId, string applicationUserId);
        Task<string> CreateRestaurant(CreateRestaurantRequestModel model, string userId);
        Task<ICollection<T>> GetRestaurants<T>();
    }
}
