namespace FoodDeliveryApp.Server.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        [HttpPost("Register")]
        public IActionResult Register(string username, string password)
        {
            return Ok(new { username, password });
        }
    }
}
