namespace MultiShop.DtoLayer.CargoDtos.CargoDetailDtos;

public class GetByIdCargoDetailDto
{
    public string? SenderCustomer { get; set; }
    public string? ReceiverCustomer { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
}