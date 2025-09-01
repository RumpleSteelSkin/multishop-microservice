using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController(
        GetAddressQueryHandler getAddressQueryHandler,
        GetAddressByIdQueryHandler getAddressByIdQueryHandler,
        CreateAddressCommandHandler createAddressCommandHandler,
        RemoveAddressCommandHandler removeAddressCommandHandler,
        UpdateAddressCommandHandler updateAddressCommandHandler) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await getAddressQueryHandler.Handle());
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id)));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateAddressCommand createAddressCommand)
        {
            await createAddressCommandHandler.Handle(createAddressCommand);
            return Ok("Address created");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
        {
            await updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Address updated");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Address removed");
        }
    }
}