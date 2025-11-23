using MovieManager.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapMoviesEndpoint();

app.Run();
