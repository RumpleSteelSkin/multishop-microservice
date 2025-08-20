using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IBrandService brandService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await brandService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await brandService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBrandDto brandDto)
        {
            await brandService.CreateAsync(brandDto);
            return Ok($"Brand {brandDto.Name} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await brandService.DeleteAsync(id);
            return Ok($"Brand {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateBrandDto brandDto)
        {
            await brandService.UpdateAsync(brandDto);
            return Ok($"Brand {brandDto.Name} updated");
        }
    }
}