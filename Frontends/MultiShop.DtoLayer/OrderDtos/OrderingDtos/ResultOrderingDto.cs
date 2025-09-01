namespace MultiShop.DtoLayer.OrderDtos.OrderingDtos;

public class ResultOrderingDto
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}