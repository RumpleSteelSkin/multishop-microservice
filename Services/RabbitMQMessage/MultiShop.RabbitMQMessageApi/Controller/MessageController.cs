using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MultiShop.RabbitMQMessageApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly ConnectionFactory _connectionFactory = new()
    {
        HostName = "localhost",
        Port = 5672,
        UserName = "guest",
        Password = "!}W^eG3802,["
    };

    [HttpPost]
    public IActionResult CreateMessage()
    {
        var channel = _connectionFactory.CreateConnection().CreateModel();
        channel.QueueDeclare("Queue1", false, false, false, null);
        channel.BasicPublish(exchange: "", routingKey: "Queue1", basicProperties: null,
            body: "Hello this is a RabbitMQ queue message"u8.ToArray());
        return Ok("Message added queue");
    }

    [HttpGet]
    public IActionResult GetMessage()
    {
        using var channel = _connectionFactory.CreateConnection().CreateModel();
        channel.QueueDeclare("Queue1", false, false, false, null);
        var result = channel.BasicGet("Queue1", true);
        if (result == null)
            return NotFound("No messages in queue");
        var message = Encoding.UTF8.GetString(result.Body.ToArray());
        return Ok(message);
    }

}