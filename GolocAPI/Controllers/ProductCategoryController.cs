using GolocAPI.Services;
using GolocSharedLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GolocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController(IProductCategoryService productCateoryService) : ControllerBase
    {
        
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductCategoryPostModel category)
        {
            try
            {
                await productCateoryService.AddCategory(category);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("list")]
        public ActionResult<List<ProductCategoryModel>> GetAll()
        {
            return Ok(productCateoryService.GetAll());
        }
    }
}
