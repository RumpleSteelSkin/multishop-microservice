namespace MultiShop.WebUI.Models;

public class MailRequest
{
    public string? ToName { get; set; }
    public string? ToMail { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}