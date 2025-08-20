using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService featureService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await featureService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await featureService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateFeatureDto featureDto)
        {
            await featureService.CreateAsync(featureDto);
            return Ok($"Feature {featureDto.Name} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await featureService.DeleteAsync(id);
            return Ok($"Feature {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateFeatureDto featureDto)
        {
            await featureService.UpdateAsync(featureDto);
            return Ok($"Feature {featureDto.Name} updated");
        }
    }
}