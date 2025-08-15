using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class OfferDiscountsController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultOfferDiscountDto>(ApiRoutes.OfferDiscounts.GetAll));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDiscountDto offerDiscount)
        {
            await jsonService.PostAsync(ApiRoutes.OfferDiscounts.Create, offerDiscount);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateOfferDiscountDto>(ApiRoutes.OfferDiscounts.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateOfferDiscountDto offerDiscount)
        {
            await jsonService.UpdateAsync(ApiRoutes.OfferDiscounts.Update, offerDiscount);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.OfferDiscounts.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}