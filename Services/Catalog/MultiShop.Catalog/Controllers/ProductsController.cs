using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await productService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            await productService.CreateAsync(productDto);
            return Ok($"Product {productDto.Name} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await productService.DeleteAsync(id);
            return Ok($"Product {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDto productDto)
        {
            await productService.UpdateAsync(productDto);
            return Ok($"Product {productDto.Name} updated");
        }
    }
}