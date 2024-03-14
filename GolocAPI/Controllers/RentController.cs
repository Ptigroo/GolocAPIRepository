using GolocAPI.Services;
using GolocAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GolocAPI.Entities;
namespace GolocAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RentController : ControllerBase
{
    private readonly IRentService rentService;
    public RentController(IRentService rentService)
    {
        this.rentService = rentService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] RentPostModel rent)
    {
        string renterId = User.Identity.GetUserId();
        await rentService.AddRent(rent, renterId);
        return Ok(new RentModel());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<ChatMessageModel>>> Get(Guid id)
    {
        return Ok(await rentService.GetMessages(id));
    }
    [Authorize]
    [HttpGet("list")]
    public ActionResult<List<RentModel>> GetAll()
    {
        string userId = User.Identity.GetUserId();
        return Ok(rentService.GetAllRents(userId));
    }
}
