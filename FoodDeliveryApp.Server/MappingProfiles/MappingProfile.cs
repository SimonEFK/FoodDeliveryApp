namespace FoodDeliveryApp.Server.MappingProfiles
{
    using AutoMapper;
    using FoodDeliveryApp.Server.Data.Models;
    using FoodDeliveryApp.Server.Models.Authentication;
    using FoodDeliveryApp.Server.Models.Restaurant;
    using FoodDeliveryApp.Server.Models.Restaurant.RestaurantListing;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ApplicationUser, LoginResponseModel>();
            this.CreateMap<Restaurant,RestaurantListingModel>();
        }
    }
}
