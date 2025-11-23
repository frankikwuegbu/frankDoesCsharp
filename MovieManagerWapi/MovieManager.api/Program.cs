using MovieManager.api.Endpoints;
using MovieManager.api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMoviesRepository, MoviesRepositoryInMemory>();

var app = builder.Build();

app.MapMoviesEndpoint();

app.Run();
