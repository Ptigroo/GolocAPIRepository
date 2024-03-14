using GolocAPI.Services;
using GolocAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GolocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductModel>> Add([FromBody] ProductPostModel product)
        {
                product.OwnerId = Guid.Parse(User.Identity.GetUserId());
                await productService.AddProduct(product);
                return new ProductModel  {};
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> Get(Guid id)
        {
                return await productService.GetProduct(id);
        }

        [HttpGet("list")]
        public ActionResult<List<ProductModel>> GetAll()
        {
            return Ok(productService.GetProducts());
        }

    }


}
