﻿namespace FoodDeliveryApp.Server.Extensions
{
    using FoodDeliveryApp.Server.Services;
    using FoodDeliveryApp.Server.Services.Authentication;

    public static class WebApplicationBuilderServiceExtension
    {

        public static void FoodDeliveryAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IJwtTokenGenerator, JWtTokenGenerator>();
            builder.Services.AddTransient<IRestaurantService, RestaurantService>();
        }
    }
}
