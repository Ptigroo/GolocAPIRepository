using GolocAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using GolocAPI.Commands;
using GolocAPI.Handlers;

namespace GolocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        //TODO Pass it to authorize with role admin[Authorize]
        [HttpPost]
        public async Task<APIResponse<ProductCategoryModel>> Add([FromBody] AddProductCategoryCommand category)
        {
            return new APIResponse<ProductCategoryModel> { Data = await mediator.Send(category) };
        }

        [HttpGet("list")]
        public async Task<APIResponse<List<ProductCategoryModel>>> GetAll()
        {
            return new APIResponse<List<ProductCategoryModel>> { Data = await mediator.Send(new GetAllProductCategoryRequest()) };
        }
    }
}
