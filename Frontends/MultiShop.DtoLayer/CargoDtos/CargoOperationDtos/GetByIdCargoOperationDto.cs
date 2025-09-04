namespace MultiShop.DtoLayer.CargoDtos.CargoOperationDtos;

public class GetByIdCargoOperationDto
{
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public DateTime OperationDate { get; set; }
}