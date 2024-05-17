namespace FoodDeliveryApp.Server.Controllers
{
    using AutoMapper;
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Models.Account;
    using FoodDeliveryApp.Server.Services.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticateUserService authenticateUserService;
        private readonly IMapper mapper;

        public UserAuthenticationController(UserManager<ApplicationUser> userManager, IAuthenticateUserService authenticateUserService, IMapper mapper)
        {
            _userManager = userManager;
            this.authenticateUserService = authenticateUserService;
            this.mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            var newUser = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    Errors = result.Errors.Select(x => x.Description).ToList()
                });
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user is null)
            {
                return Unauthorized("Invalid Login Credentials");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid Login Credentials");
            }
            var token = authenticateUserService.AuthenticateUser(user);

            var loginResponseModel = mapper.Map<LoginResponseModel>(user);

            return Ok(loginResponseModel);
        }
    }
}
