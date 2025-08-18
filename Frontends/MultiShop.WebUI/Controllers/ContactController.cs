using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Index(CreateContactDto createContactDto)
        {
            await jsonService.PostAsync(ApiRoutes.Contacts.Create, createContactDto);
            return RedirectToAction("Index", "Default");
        }
    }
}