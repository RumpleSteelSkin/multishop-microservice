using Microsoft.AspNetCore.SignalR;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Hooks;

namespace MultiShop.WebUI.Hubs;

public class SignalRHub(JsonService jsonService) : Hub
{
    public static int ClientCount { get; set; }

    public async Task SendStatistics()
    {
        await Clients.All.SendAsync("ReceiveStatistics", new Dictionary<string, object>
        {
            ["DiscountGetCount"] = await jsonService.GetAsync<int>(ApiRoutes.Discounts.GetCount),
            ["CategoryGetCount"] = await jsonService.GetAsync<int>(ApiRoutes.Categories.GetCount),
            ["BrandGetCount"] = await jsonService.GetAsync<int>(ApiRoutes.Brands.GetCount),
            ["ProductGetCount"] = await jsonService.GetAsync<int>(ApiRoutes.Products.GetCount),
            ["ProductGetMaxPriceProductName"] = await jsonService.GetAsync<string>(ApiRoutes.Products.GetMaxPriceProductName) ?? string.Empty,
            ["ProductGetMinPriceProductName"] = await jsonService.GetAsync<string>(ApiRoutes.Products.GetMinPriceProductName) ?? string.Empty,
            ["UsersGetCount"] = await jsonService.GetAsync<int>(ApiRoutes.Users.GetUserCount),
            ["CommentGetActiveCommentCount"] = await jsonService.GetAsync<int>(ApiRoutes.Comments.GetActiveCommentCount),
            ["CommentGetPassiveCommentCount"] = await jsonService.GetAsync<int>(ApiRoutes.Comments.GetPassiveCommentCount),
            ["UserMessageGetCount"] = await jsonService.GetAsync<int>(ApiRoutes.UserMessage.GetCount),
            ["ProductGetAvgPrice"] = $"{(await jsonService.GetAsync<decimal>(ApiRoutes.Products.GetProductAvgPrice)):0.00} $"
        });
    }

    public async Task SendNotifies()
    {
        var totalCommentCount = await jsonService.GetAsync<int>(ApiRoutes.Comments.GetActiveCommentCount) +
                                await jsonService.GetAsync<int>(ApiRoutes.Comments.GetPassiveCommentCount);
        await Clients.All.SendAsync("ReceiveNotifies", new Dictionary<string, object>
        {
            ["CommentCount"] = totalCommentCount,
            ["MessageCount"] = await jsonService.GetAsync<int>(ApiRoutes.UserMessage.GetCount)
        });
    }
}