using GolocAPI.Services;
using GolocSharedLibrary.Models;
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
            try
            {
                product.OwnerId = Guid.Parse(User.Identity.GetUserId());
                await productService.AddProduct(product);
                return new ProductModel  {};
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {
            return Ok( await productService.GetProducts());
        }

    }


}
