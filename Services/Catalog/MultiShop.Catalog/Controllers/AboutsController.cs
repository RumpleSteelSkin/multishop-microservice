using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.About;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutService aboutService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await aboutService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await aboutService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateAboutDto aboutDto)
        {
            await aboutService.CreateAsync(aboutDto);
            return Ok($"About {aboutDto.Description} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await aboutService.DeleteAsync(id);
            return Ok($"About {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateAboutDto aboutDto)
        {
            await aboutService.UpdateAsync(aboutDto);
            return Ok($"About {aboutDto.Description} updated");
        }
    }
}