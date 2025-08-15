using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.ViewModels;

public class CategoryWithProductNumber
{
    public ResultCategoryDto? ResultCategoryDto { get; set; }
    public int ProductCounts { get; set; }
}