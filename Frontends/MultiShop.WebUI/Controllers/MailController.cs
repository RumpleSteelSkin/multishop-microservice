using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace MultiShop.WebUI.Controllers;

public class MailController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(MailRequest email)
    {
        using var message = new MimeMessage();
        var mailboxAddressFrom = new MailboxAddress("MultiShop Catalog", "rstelskin@gmail.com");
        message.From.Add(mailboxAddressFrom);
        var mailboxAddressTo = new MailboxAddress(email.ToName, email.ToMail);
        message.To.Add(mailboxAddressTo);
        message.Subject = email.Subject;
        var bodyBuilder = new BodyBuilder
        {
            TextBody = email.Body
        };
        message.Body = bodyBuilder.ToMessageBody();

        var  smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);
        smtpClient.Authenticate("rstelskin@gmail.com","qowkyorvkhvghhhc");
        smtpClient.Send(message);
        smtpClient.Disconnect(true);
        return View();
    }
}