using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

public class WeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<WeatherService> _logger;
    private readonly string _apiKey = "fea475113121343514ff172def13ab76";
    public WeatherService(IHttpClientFactory httpClientFactory, ILogger<WeatherService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<WeatherResponseDto> GetWeatherAsync(string city)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("OpenWeatherMap");
            var response = await client.GetAsync($"weather?q={city}&appid={_apiKey}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var weatherResponse = JsonSerializer.Deserialize<WeatherResponseDto>(jsonResult);
                return weatherResponse;
            }
            _logger.LogError($"Failed to fetch weather data for {city}: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while fetching weather data for {city}");
        }

        return new WeatherResponseDto
        {
            CityName = "city not found",
            MainInfo = new WeatherResponseDto.Main { Temp = 0, FeelsLike = 0 },
            Country = new WeatherResponseDto.Sys { CountryName = "country not found" }
        };
    }
}