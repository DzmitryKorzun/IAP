using IAP.Infrustructure.Models;
using IAP.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IAP.Web.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            this.userService = userService;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Auth([FromBody]UserLoggingModel data)
        {
            var isValid = await userService.IsLogging(data);
            if (isValid.Data)
            {
                var tokenString = userService.GenerateJwtToken(data.Email, configuration);
                return Ok(new { Token = tokenString, Message = "Success" });
            }
            return BadRequest("Please pass the valid Username and Password");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserModel newUser)
        {
            var result = await userService.RegisterNewUser(newUser);
            if (result.Status == Infrustructure.Enums.ResponseStatus.OK)
            {
                return Ok();
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public string? GetCurrentUser()
        {
            return User?.Identity?.Name;
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<int> GetCountOfUser()
        {
            var response = await userService.GetCountOfUser();
            return response.Data;
        }
    }
}
