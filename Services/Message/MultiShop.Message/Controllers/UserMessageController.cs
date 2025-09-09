using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserMessageController(IUserMessageService userMessageService) : ControllerBase
{
    [Authorize(Policy = "MessageRead")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await userMessageService.GetAllMessageAsync());
    }

    [HttpGet("GetAllSendBoxMessage/{id}")]
    [Authorize(Policy = "MessageRead")]
    public async Task<IActionResult> GetAllSendBoxMessage(string? id)
    {
        return Ok(await userMessageService.GetAllSendBoxMessageAsync(id));
    }

    [HttpGet("GetAllInBoxMessage/{id}")]
    [Authorize(Policy = "MessageRead")]
    public async Task<IActionResult> GetAllInBoxMessage(string? id)
    {
        return Ok(await userMessageService.GetAllInBoxMessageAsync(id));
    }

    [HttpGet("GetById/{id:int}")]
    [Authorize(Policy = "MessageRead")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await userMessageService.GetByIdMessageAsync(id));
    }

    [HttpGet("GetCountByReceiverId/{id}")]
    [Authorize(Policy = "MessageRead")]
    public async Task<IActionResult> GetCountByReceiverId(string id)
    {
        return Ok(await userMessageService.GetCountByReceiverId(id));
    }
    
    [HttpGet("GetCount")]
    [Authorize(Policy = "MessageRead")]
    public async Task<IActionResult> GetCount()
    {
        return Ok(await userMessageService.GetCount());
    }

    [HttpPost("Create")]
    [Authorize(Policy = "MessageHalf")]
    public async Task<IActionResult> CreateAsync(CreateMessageDto createMessageDto)
    {
        await userMessageService.CreateMessageAsync(createMessageDto);
        return Ok("User message created");
    }

    [HttpPut("Update")]
    [Authorize(Policy = "MessageWrite")]
    public async Task<IActionResult> UpdateAsync(UpdateMessageDto updateMessageDto)
    {
        await userMessageService.UpdateMessageAsync(updateMessageDto);
        return Ok("User message updated");
    }

    [HttpDelete("Delete/{id:int}")]
    [Authorize(Policy = "MessageWrite")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await userMessageService.DeleteMessageAsync(id);
        return Ok("User message deleted");
    }
}