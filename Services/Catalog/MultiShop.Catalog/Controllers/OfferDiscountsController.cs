using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController(IOfferDiscountService offerDiscountService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await offerDiscountService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await offerDiscountService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOfferDiscountDto offerDiscountDto)
        {
            await offerDiscountService.CreateAsync(offerDiscountDto);
            return Ok($"OfferDiscount {offerDiscountDto.Title} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await offerDiscountService.DeleteAsync(id);
            return Ok($"OfferDiscount {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateOfferDiscountDto offerDiscountDto)
        {
            await offerDiscountService.UpdateAsync(offerDiscountDto);
            return Ok($"OfferDiscount {offerDiscountDto.Title} updated");
        }
    }
}