using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.ValidationDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Hooks;

public class JsonService(IHttpClientFactory httpClientFactory)
{
    private readonly HttpClient _client = httpClientFactory.CreateClient();

    public async Task<ICollection<T>?> GetAllAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);
        return !response.IsSuccessStatusCode
            ? null
            : JsonConvert.DeserializeObject<ICollection<T>>(await response.Content.ReadAsStringAsync());
    }
    
    public async Task<ICollection<T>?> GetAllByIdAsync<T>(string url, string id)
    {
        var response = await _client.GetAsync($"{url}/{id}");
        return !response.IsSuccessStatusCode
            ? null
            : JsonConvert.DeserializeObject<ICollection<T>>(await response.Content.ReadAsStringAsync());
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        var response = await _client.GetAsync(url);
        return !response.IsSuccessStatusCode
            ? default
            : JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }

    public async Task<T?> GetByIdAsync<T>(string url, string id)
    {
        var response = await _client.GetAsync($"{url}/{id}");
        if (!response.IsSuccessStatusCode)
            throw new Exception(
                $"Data extraction error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }

    public async Task<bool> PostAsync<TRequest>(string url, TRequest data, ModelStateDictionary modelState)
    {
        var response = await _client.PostAsync(url,
            new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        if (response.IsSuccessStatusCode)
            return true;
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var validationErrors =
                JsonConvert.DeserializeObject<FluentValidationErrorResponse>(
                    await response.Content.ReadAsStringAsync());
            if (validationErrors?.Errors == null) return false;
            foreach (var error in validationErrors.Errors)
            {
                foreach (var msg in error.Errors!)
                {
                    modelState.AddModelError(error.Property!, msg);
                }
            }

            return false;
        }

        throw new Exception($"API error: {response.StatusCode}");
    }

    public async Task PostAsync<TRequest>(string url, TRequest data)
    {
        var response = await _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
            throw new Exception(
                $"Data extraction error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }

    public async Task DeleteAsync(string url, string id)
    {
        var response = await _client.DeleteAsync($"{url}/{id}");
        if (!response.IsSuccessStatusCode)
            throw new Exception(
                $"Deletion Failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }

    public async Task UpdateAsync<T>(string url, T data)
    {
        var response = await _client.PutAsync(url,
            new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Update failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }
    public async Task<ICollection<SelectListItem>> GetSelectListAsync<T>(string url, Func<T, string?> textSelector, Func<T, string?> valueSelector)
    {
        var data = await GetAllAsync<T>(url);
        return data == null ? [] : data.Select(item => new SelectListItem { Text = textSelector(item), Value = valueSelector(item) }).ToList();
    }
}