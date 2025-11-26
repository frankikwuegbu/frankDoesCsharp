using MovieManager.api.Data;
using MovieManager.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

//implementing IMoviesRepository
builder.Services.AddRepository(builder.Configuration);

var app = builder.Build();

//applies migration if needed
await app.Services.InitializeDbAsync();

app.MapMoviesEndpoint();

app.Run();
