namespace MultiShop.DtoLayer.OrderDtos.OrderDetailDtos;

public class ResultOrderDetailDto
{
    public int Id { get; set; }
    public string? ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderingId { get; set; }
}