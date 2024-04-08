using GolocAPI.Services;
using GolocAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GolocAPI.CommandsAndQueries.Authentication;
using GolocAPI.CommandsAndQueries;
using GolocAPI.Handlers;
namespace GolocAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<APIResponse<RentModel>> Add([FromBody] AddRentCommand rent)
    {
        rent.RenterId = User.Identity.GetUserId();
        return new APIResponse<RentModel> { Data = await mediator.Send(rent) };
    }
    [HttpGet("{id}")]
    public async Task<APIResponse<List<ChatMessageModel>>> Get(Guid id)
    {
        return new APIResponse<List<ChatMessageModel>> { Data = await mediator.Send(new GetMessagesQuery(id)) };
    }
    [Authorize]
    [HttpGet("list")]
    public async Task<APIResponse<List<RentModel>>> GetAll()
    {
        string userId = User.Identity.GetUserId();
        return new APIResponse<List<RentModel>> { Data = await mediator.Send(new GetAllRentsQuery(userId)) };
    }
}
