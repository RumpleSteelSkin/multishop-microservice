using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoryService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await categoryService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            await categoryService.CreateAsync(categoryDto);
            return Ok($"Category {categoryDto.Name} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await categoryService.DeleteAsync(id);
            return Ok($"Category {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            await categoryService.UpdateAsync(categoryDto);
            return Ok($"Category {categoryDto.Name} updated");
        }
    }
}