using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.MessageDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Areas.User.Controllers;

[Area("User")]
[Route("User/[controller]/[action]")]
public class MessageController(JsonService jsonService) : Controller
{
    public async Task<ActionResult> InBox()
    {
        return View(await jsonService.GetAllByIdAsync<ResultInBoxMessageDto>(ApiRoutes.UserMessage.GetAllInBoxMessage,
            jsonService.GetUserId() ?? throw new AuthenticationException("User not found")));
    }
    public async Task<ActionResult> SendBox()
    {
        return View(await jsonService.GetAllByIdAsync<ResultSendBoxMessageDto>(ApiRoutes.UserMessage.GetAllSendBoxMessage,
            jsonService.GetUserId() ?? throw new AuthenticationException("User not found")));
    }
    public async Task<ActionResult> ChangeRead(int id, bool read)
    {
        var message = await jsonService.GetByIdAsync<GetByIdMessageDto>(ApiRoutes.UserMessage.GetById, id.ToString());
        if (message is null) throw new KeyNotFoundException("Message not found");
        await jsonService.UpdateAsync(ApiRoutes.UserMessage.Update, new UpdateMessageDto
        {
            Id = id,
            Date = message.Date,
            IsRead = read,
            MessageDetail = message.MessageDetail,
            ReceiverId = message.ReceiverId,
            SenderId = message.SenderId,
            Subject = message.Subject,
        });
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteMessage(int id)
    {
        await jsonService.DeleteAsync(ApiRoutes.UserMessage.GetById, id.ToString());
        return NoContent();
    }
}