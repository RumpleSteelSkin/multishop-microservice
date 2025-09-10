using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApi.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApi.WebUI.Controllers;

public class DefaultController : Controller
{
    public async Task<IActionResult> Weather()
    {
        using var response = await new HttpClient().SendAsync(new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
            Headers =
            {
                { "x-rapidapi-key", "f3ccbc4644mshbb4eec433818f78p13f072jsn9fd2e1ff2cf5" },
                { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
            },
        });
        response.EnsureSuccessStatusCode();
        return View(JsonConvert.DeserializeObject<RootObject>(await response.Content.ReadAsStringAsync()));
    }

    public async Task<IActionResult> Exchange()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
            Headers =
            {
                { "x-rapidapi-key", "f3ccbc4644mshbb4eec433818f78p13f072jsn9fd2e1ff2cf5" },
                { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
            },
        };
        using var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return View(JsonConvert.DeserializeObject<ExchangeViewModel.RootObject>(await response.Content.ReadAsStringAsync()));
    }
    
    
}