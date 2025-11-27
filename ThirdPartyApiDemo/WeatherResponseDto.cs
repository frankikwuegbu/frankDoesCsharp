using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

//data transfer objects are used to model data response and/or entry
public class WeatherResponseDto
{
    [JsonPropertyName("name")]
    public string CityName { get; set; } = string.Empty;

    [JsonPropertyName("sys")]
    public Sys Country { get; set; } = new Sys();

    [JsonPropertyName("main")]
    public Main MainInfo { get; set; } = new Main();

    public class Sys
    {
        [JsonPropertyName("country")]
        public string CountryName { get; set; } = string.Empty;
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
    }
}


