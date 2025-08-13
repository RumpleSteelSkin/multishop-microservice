using Newtonsoft.Json;

namespace MultiShop.WebUI.Hooks;

public class JsonService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _client = httpClientFactory.CreateClient();

    public async Task<ICollection<T>?> GetAllAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);
        return !response.IsSuccessStatusCode ? null : JsonConvert.DeserializeObject<ICollection<T>>(await response.Content.ReadAsStringAsync());
    }
}