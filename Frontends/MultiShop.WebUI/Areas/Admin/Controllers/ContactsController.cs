using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ContactsController(JsonService jsonService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await jsonService.GetAllAsync<ResultContactDto>(ApiRoutes.Contacts.GetAll));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto contact)
        {
            contact.IsRead = false;
            await jsonService.PostAsync(ApiRoutes.Contacts.Create, contact);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Update(string id)
        {
            return View(await jsonService.GetByIdAsync<UpdateContactDto>(ApiRoutes.Contacts.GetById, id));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(UpdateContactDto contact)
        {
            await jsonService.UpdateAsync(ApiRoutes.Contacts.Update, contact);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await jsonService.DeleteAsync(ApiRoutes.Contacts.Delete, id);
            return RedirectToAction(nameof(Index));
        }
    }
}