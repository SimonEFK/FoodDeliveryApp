namespace FoodDeliveryApp.Server.Controllers
{
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Models;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTestController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public AccountTestController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var newUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true

            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(model);
        }
    }
}
