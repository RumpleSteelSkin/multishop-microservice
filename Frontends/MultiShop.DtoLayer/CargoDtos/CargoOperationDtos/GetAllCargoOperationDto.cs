namespace MultiShop.DtoLayer.CargoDtos.CargoOperationDtos;

public class GetAllCargoOperationDto
{
    public int Id { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public DateTime OperationDate { get; set; }
}