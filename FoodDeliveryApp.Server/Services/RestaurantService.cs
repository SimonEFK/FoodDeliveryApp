namespace FoodDeliveryApp.Server.Services
{
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Data.Models;

    public class RestaurantService : IRestaurantService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RestaurantService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void CreateRestaurant()
        {


        }
    }
}
