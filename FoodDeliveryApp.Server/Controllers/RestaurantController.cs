namespace FoodDeliveryApp.Server.Controllers
{
    using FoodDeliveryApp.Server.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpPost]
        public IActionResult CreateRestaurant()
        {
            this.restaurantService.CreateRestaurant();

            return Ok();

        }
    }
}
