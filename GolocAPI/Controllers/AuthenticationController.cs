using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.Models;
using GolocAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace GolocAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<APIResponse<TokenModel>> Login(LoginQuery login)
    {
        return new APIResponse<TokenModel> { Data = await mediator.Send(login) };
    }
    [HttpPost("register")]
    public async Task<APIResponse<TokenModel>> RegisterAndLogin([FromBody] RegisterCommand register)
    {
        await mediator.Send(register);
        return new APIResponse<TokenModel> { Data = await mediator.Send(new LoginQuery(register.Login, register.Password)) };
    }
}
