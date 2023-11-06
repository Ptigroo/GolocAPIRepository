using GolocAPI.Entities;
using GolocSharedLibrary.Models;
using GolocAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GolocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _manager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(UserManager<User> manager, IAuthenticationService authenticationService)
        {
            _manager = manager;
            _authenticationService = authenticationService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginModel login)
        {
            return Ok(await _authenticationService.Login(login));
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
                return Ok(await _authenticationService.Register(register));
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
