using GolocAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using GolocAPI.CommandsAndQueries;
namespace GolocAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(IMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<APIResponse<ProductModel>> AddProduct([FromBody] AddProductCommand product)
    {
        product.OwnerId = Guid.Parse(User.Identity.GetUserId());
        await mediator.Send(product);
        return new APIResponse<ProductModel>() { Data = await mediator.Send(product) };
    }
    [HttpGet("{id}")]
    public async Task<APIResponse<ProductModel>> Get(Guid id)
    {
        return new APIResponse<ProductModel> { Data= await mediator.Send(new GetProductByIdQuery(id)) };
    }

    [HttpGet("list")]
    public async Task<APIResponse<List<ProductModel>>> GetAll()
    {
        return new APIResponse<List<ProductModel>>{ Data =await mediator.Send(new GetAllProductsQuery())};
    }
    [HttpGet("paginated")]
    public async Task<APIResponse<PaginatedList<ProductModel>>> GetAllProductsPaginated(int pageNumber, int pageSize)
    {
        return new APIResponse<PaginatedList<ProductModel>> { Data = await mediator.Send(new GetAllProductPaginatedQuery(pageNumber, pageSize)) };
    }

}
