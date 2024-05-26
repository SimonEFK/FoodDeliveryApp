namespace FoodDeliveryApp.Server.Controllers
{
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.MenuItem;
    using FoodDeliveryApp.Server.Models.Restaurant.RestaurantListing;
    using FoodDeliveryApp.Server.Services;
    using FoodDeliveryApp.Server.Services.Resturant;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class RestaurantController : ApiBaseController
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpPost("/api/restaurants")]
        public async Task<IActionResult> CreateRestaurant(RestaurantCreateRequestModel model)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return BadRequest("");
            }

            var result = await this.restaurantService.CreateRestaurant(userId, model);
            var response = new RestaurantCreateResponseModel { Id = userId };
            return Created();

        }

        [HttpPost("/api/restaurants/{restaurantId}/menu")]
        public async Task<IActionResult> AddItemToMenu(string restaurantId, MenuItemCreateRequestModel model)
        {
            var userId = this.GetUserId();
            await this.restaurantService.AddItemToRestaurant(userId, restaurantId, model);
            return Created();
        }



        [HttpGet("{id?}")]
        public async Task<IActionResult> GetRestaurant(string? id)
        {
            var restaurants = await this.restaurantService.GetRestaurants<RestaurantListingModel>();
            return Ok(restaurants);
        }

    }
}
