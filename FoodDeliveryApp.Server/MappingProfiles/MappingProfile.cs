namespace FoodDeliveryApp.Server.MappingProfiles
{
    using AutoMapper;
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Models.Account;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ApplicationUser, LoginResponseModel>();

        }
    }
}
