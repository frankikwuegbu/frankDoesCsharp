using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//api url and the accepted return format
builder.Services.AddHttpClient("OpenWeatherMap", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");   //api url
    client.DefaultRequestHeaders.Add("Accept", "application/json");             //return in json format
});

//registers the weather service
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//mapping weather services to a route
app.MapGet("/weather/{city}", async ([FromServices] WeatherService weatherService, string city) =>
{
    var weather = await weatherService.GetWeatherAsync(city);
    return Results.Ok(weather);
});

app.Run();
