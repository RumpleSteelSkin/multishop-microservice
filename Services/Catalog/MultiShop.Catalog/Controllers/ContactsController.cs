using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IContactService contactService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await contactService.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await contactService.GetByIdAsync(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateContactDto contactDto)
        {
            await contactService.CreateAsync(contactDto);
            return Ok($"Contact {contactDto.NameSurname} created");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await contactService.DeleteAsync(id);
            return Ok($"Contact {id} deleted");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateContactDto contactDto)
        {
            await contactService.UpdateAsync(contactDto);
            return Ok($"Contact {contactDto.NameSurname} updated");
        }
    }
}