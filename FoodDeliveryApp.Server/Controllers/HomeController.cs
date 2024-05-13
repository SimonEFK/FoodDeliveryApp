namespace FoodDeliveryApp.Server.Controllers
{
    
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        
    }
}
