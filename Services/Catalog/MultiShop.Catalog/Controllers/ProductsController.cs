using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await productService.GetAllAsync());
    }

    [HttpGet("GetCount")]
    public async Task<IActionResult> GetCount()
    {
        return Ok(await productService.GetCountAsync());
    }

    [HttpGet("GetProductAvgPrice")]
    public IActionResult GetProductAvgPrice()
    {
        return Ok(productService.GetAllAsync().Result.Select(x => x.Price).Average());
    }
    
    [HttpGet("GetMaxPriceProductName")]
    public IActionResult GetMaxPriceProductName()
    {
        return Ok(productService.GetAllAsync().Result.MaxBy(x=>x.Price)?.Name);
    }
    
    [HttpGet("GetMinPriceProductName")]
    public IActionResult GetMinPriceProductName()
    {
        return Ok(productService.GetAllAsync().Result.MinBy(x=>x.Price)?.Name);
    }

    [HttpGet("GetAllWithCategory")]
    public async Task<IActionResult> GetAllWithCategory()
    {
        return Ok(await productService.GetAllWithCategoryAsync());
    }

    [HttpGet("GetAllWithCategoryByCategoryId/{id}")]
    public async Task<IActionResult> GetAllWithCategoryByCategoryId(string id)
    {
        return Ok(await productService.GetAllWithCategoryByCategoryIdAsync(id));
    }

    [HttpGet("GetCountByCategoryId/{id}")]
    public async Task<IActionResult> GetCountByCategoryId(string id)
    {
        return Ok((await productService.GetAllAsync(x => x.CategoryId == id)).Count);
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