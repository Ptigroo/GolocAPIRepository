using GolocAPI.Entities;
using GolocSharedLibrary.Models;
using GolocAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GolocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(UserManager<User> manager, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginModel login)
        {
            try
            {
                return Ok(await _authenticationService.Login(login));
            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionModel() { Message = e.Message});
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
            try
            {
                return Ok(await _authenticationService.Register(register));

            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionModel() { Message = e.Message});
            }
                
        }
        [HttpGet("list")]
        public async Task<List<UserModel>> UserList()
        {
            return await _authenticationService.ListUsers();
        }
        /*[HttpPost("forgot")]
        public async Task<ActionResult> Forgot(ForgotPasswordModel forgot)
        {
                await _authenticationService.Forgot(forgot);
                return Ok();
        }
        [HttpGet("validate/{user}")]
        public async Task Validate(string user)
        {
                await _authenticationService.Validate(user);
        }*/
    }
}
