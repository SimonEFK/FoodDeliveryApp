namespace FoodDeliveryApp.Server.Controllers
{
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.Menu;
    using FoodDeliveryApp.Server.Services.Resturant;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    public class RestaurantController : ApiBaseController
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }


        [AllowAnonymous]
        [HttpGet("/api/restaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await restaurantService.GetRestaurants<RestaurantResponseModel>();

            return Ok(restaurants);
        }

        [HttpPost("/api/restaurant")]
        public async Task<IActionResult> CreateRestaurant(CreateRestaurantRequestModel model)
        {
            var userId = this.GetUserId();
            var result = await this.restaurantService.CreateRestaurant(model, userId);
            return Ok(result);
        }

        [HttpPost("/api/restaurant/{restaurantId}/menu")]
        public async Task<IActionResult> AddItemToMenu(string restaurantId, CreateItemRequestModel model)
        {
            var userId = this.GetUserId();
            await this.restaurantService.AddItemToRestaurantMenu(
                model,
                restaurantId,
                userId);
            return Ok();
        }
    }
}
