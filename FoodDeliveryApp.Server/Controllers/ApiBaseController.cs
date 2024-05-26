namespace FoodDeliveryApp.Server.Controllers
{
    using FoodDeliveryApp.Server.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public abstract class ApiBaseController : ControllerBase
    {

        protected string? GetUserId()
        => this.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
