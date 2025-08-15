using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class SpecialOffersController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultSpecialOfferDto>(ApiRoutes.SpecialOffers.GetAll));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialOfferDto specialOffer)
        {
            await jsonService.PostAsync(ApiRoutes.SpecialOffers.Create, specialOffer);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateSpecialOfferDto>(ApiRoutes.SpecialOffers.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto specialOffer)
        {
            await jsonService.UpdateAsync(ApiRoutes.SpecialOffers.Update, specialOffer);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.SpecialOffers.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}