using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController(IFeatureSliderService featureSliderService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await featureSliderService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await featureSliderService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateFeatureSliderDto featureSliderDto)
        {
            await featureSliderService.CreateAsync(featureSliderDto);
            return Ok($"FeatureSlider {featureSliderDto.Title} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await featureSliderService.DeleteAsync(id);
            return Ok($"FeatureSlider {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto featureSliderDto)
        {
            await featureSliderService.UpdateAsync(featureSliderDto);
            return Ok($"FeatureSlider {featureSliderDto.Title} updated");
        }
    }
}