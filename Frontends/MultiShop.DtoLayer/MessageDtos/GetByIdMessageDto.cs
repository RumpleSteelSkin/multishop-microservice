namespace MultiShop.DtoLayer.MessageDtos;

public class GetByIdMessageDto
{
    public string? SenderId { get; set; }
    public string? ReceiverId { get; set; }
    public string? Subject { get; set; }
    public string? MessageDetail { get; set; }
    public DateTime Date { get; set; }
    public bool IsRead { get; set; }
}