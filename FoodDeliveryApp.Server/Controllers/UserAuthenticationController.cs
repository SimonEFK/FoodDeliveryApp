namespace FoodDeliveryApp.Server.Controllers
{
    using AutoMapper;
    using FoodDeliveryApp.Server.AppSettings;
    using FoodDeliveryApp.Server.Data;
    using FoodDeliveryApp.Server.Models.Account;
    using FoodDeliveryApp.Server.Services.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.Extensions.Options;

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
                EmailConfirmed = true

            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel loginModel)
        {

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
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
