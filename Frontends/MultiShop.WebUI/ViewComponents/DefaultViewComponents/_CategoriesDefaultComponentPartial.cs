using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;
using MultiShop.WebUI.ViewModels;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents;

public class _CategoriesDefaultComponentPartial(JsonService jsonService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = await jsonService.GetAllAsync<ResultCategoryDto>(ApiRoutes.Categories.GetAll);
        List<CategoryWithProductNumber> categoriesWithProductCount = [];
        if (categoriesWithProductCount == null) throw new ArgumentNullException(nameof(categoriesWithProductCount));
        if (categories == null) return View();
        foreach (var category in categories)
        {
            categoriesWithProductCount.Add(new CategoryWithProductNumber
            {
                ResultCategoryDto = category,
                ProductCounts =
                    await jsonService.GetAsync<int>($"{ApiRoutes.Products.GetCountByCategoryId}/{category.Id}")
            });
        }

        return View(categoriesWithProductCount);
    }
}