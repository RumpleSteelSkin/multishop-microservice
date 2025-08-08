using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IDiscountService discountService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await discountService.GetAll());
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await discountService.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            await discountService.Create(createCouponDto);
            return Ok($"Discount {createCouponDto.Code} was created successfully");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {
            await discountService.Update(updateCouponDto);
            return Ok($"Discount {updateCouponDto.Code} was updated successfully");
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await discountService.Delete(id);
            return Ok($"Discount {id} was deleted successfully");
        }
    }
}
