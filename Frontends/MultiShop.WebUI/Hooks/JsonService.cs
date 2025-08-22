using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.ValidationDtos;
using MultiShop.WebUI.Constant;
using MultiShop.WebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Hooks;

public class JsonService(
    IHttpClientFactory httpClientFactory,
    IHttpContextAccessor httpContextAccessor,
    IConfiguration configuration)
{
    private readonly HttpClient _client = httpClientFactory.CreateClient();

    /// <summary>
    /// Access token yoksa refresh token ile yenile.
    /// Varsa Authorization header’a ekle.
    /// </summary>
    private async Task AddJwtTokenHeaderAsync()
    {
        var context = httpContextAccessor.HttpContext;
        var accessToken = context?.Request.Cookies["access_token"];
        var refreshToken = context?.Request.Cookies["refresh_token"];

        if (string.IsNullOrWhiteSpace(accessToken) && !string.IsNullOrWhiteSpace(refreshToken))
        {
            var newToken = await RefreshTokenAsync(refreshToken);
            if (newToken != null)
            {
                accessToken = newToken.AccessToken;
                SaveTokensToCookies(context!, newToken);
            }
        }

        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }

    /// <summary>
    /// Refresh token kullanarak yeni access token alır.
    /// </summary>
    private async Task<TokenResponseDto?> RefreshTokenAsync(string refreshToken)
    {
        var response = await _client.PostAsync(ApiRoutes.Connect.Token,
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", "MultiShopAdminId" },
                { "client_secret", configuration["Jwt:Secret"]! },
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken }
            }));

        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TokenResponseDto>(content);
    }

    /// <summary>
    /// Username/password ile token alır ve cookie’ye yazar.
    /// </summary>
    public async Task<TokenResponseDto?> GetTokenAsync(string username, string password)
    {
        var response = await _client.PostAsync(ApiRoutes.Connect.Token,
            new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "client_id", "MultiShopAdminId" },
                { "client_secret", configuration["Jwt:Secret"]! },
                { "grant_type", "password" },
                { "username", username },
                { "password", password }
            }));

        if (!response.IsSuccessStatusCode) return null;

        var content = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDto>(content);

        if (tokenResponse != null)
        {
            SaveTokensToCookies(httpContextAccessor.HttpContext!, tokenResponse);
        }

        return tokenResponse;
    }

    /// <summary>
    /// Access ve refresh token’ları cookie’ye yazar.
    /// </summary>
    private static void SaveTokensToCookies(HttpContext context, TokenResponseDto tokenResponse)
    {
        if (!string.IsNullOrEmpty(tokenResponse.AccessToken))
        {
            context.Response.Cookies.Append(
                "access_token",
                tokenResponse.AccessToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn)
                });
        }

        if (!string.IsNullOrEmpty(tokenResponse.RefreshToken))
        {
            context.Response.Cookies.Append(
                "refresh_token",
                tokenResponse.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
        }
    }

    #region CRUD Methods

    public async Task<ICollection<T>?> GetAllAsync<T>(string url)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.GetAsync(url);
        return !response.IsSuccessStatusCode
            ? null
            : JsonConvert.DeserializeObject<ICollection<T>>(await response.Content.ReadAsStringAsync());
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.GetAsync(url);
        return !response.IsSuccessStatusCode
            ? default
            : JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }

    public async Task<T?> GetByIdAsync<T>(string url, string id)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.GetAsync($"{url}/{id}");
        return response.StatusCode is HttpStatusCode.Forbidden or HttpStatusCode.Unauthorized
            ? default
            : JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }

    public async Task<bool> PostAsync<TRequest>(string url, TRequest data, ModelStateDictionary modelState)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.PostAsync(url,
            new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

        if (response.IsSuccessStatusCode) return true;

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var validationErrors =
                JsonConvert.DeserializeObject<FluentValidationErrorResponse>(
                    await response.Content.ReadAsStringAsync());
            if (validationErrors?.Errors != null)
            {
                foreach (var error in validationErrors.Errors)
                {
                    foreach (var msg in error.Errors!)
                    {
                        modelState.AddModelError(error.Property!, msg);
                    }
                }
            }

            return false;
        }

        throw new Exception($"API error: {response.StatusCode}");
    }

    public async Task PostAsync<TRequest>(string url, TRequest data)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.PostAsync(url,
            new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
    }

    public async Task DeleteAsync(string url, string id)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.DeleteAsync($"{url}/{id}");
        if (response is
            { IsSuccessStatusCode: false, StatusCode: HttpStatusCode.Forbidden or HttpStatusCode.Unauthorized })
        {
            httpContextAccessor.HttpContext!.Response.StatusCode = (int)response.StatusCode;
        }
    }

    public async Task UpdateAsync<T>(string url, T data)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.PutAsync(url,
            new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Update failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
    }

    public async Task<ICollection<T>?> GetAllByIdAsync<T>(string url, string id)
    {
        await AddJwtTokenHeaderAsync();
        var response = await _client.GetAsync($"{url}/{id}");
        return !response.IsSuccessStatusCode
            ? null
            : JsonConvert.DeserializeObject<ICollection<T>>(await response.Content.ReadAsStringAsync());
    }


    public async Task<ICollection<SelectListItem>> GetSelectListAsync<T>(string url, Func<T, string?> textSelector,
        Func<T, string?> valueSelector)
    {
        await AddJwtTokenHeaderAsync();
        var data = await GetAllAsync<T>(url);
        return data == null
            ? []
            : data.Select(item => new SelectListItem { Text = textSelector(item), Value = valueSelector(item) })
                .ToList();
    }

    #endregion
}