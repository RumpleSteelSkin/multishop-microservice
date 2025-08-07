using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(
    GetOrderDetailQueryHandler getOrderDetailQueryHandler,
    GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
    CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
    RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler,
    UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await getOrderDetailQueryHandler.Handle());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id)));
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateOrderDetailCommand createOrderDetailCommand)
    {
        await createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
        return Ok("OrderDetail created");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        await updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
        return Ok("OrderDetail updated");
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
        return Ok("OrderDetail removed");
    }
}