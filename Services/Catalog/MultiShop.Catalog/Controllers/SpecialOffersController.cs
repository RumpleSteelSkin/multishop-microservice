using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController(ISpecialOfferService specialOfferService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await specialOfferService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await specialOfferService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateSpecialOfferDto specialOfferDto)
        {
            await specialOfferService.CreateAsync(specialOfferDto);
            return Ok($"SpecialOffer {specialOfferDto.Title} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await specialOfferService.DeleteAsync(id);
            return Ok($"SpecialOffer {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto specialOfferDto)
        {
            await specialOfferService.UpdateAsync(specialOfferDto);
            return Ok($"SpecialOffer {specialOfferDto.Title} updated");
        }
    }
}