using LoginPageDemo.entities;
using LoginPageDemo.entities.endpoints;
using LoginPageDemo.repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserRepository, LocalUserRepository>();

var app = builder.Build();
app.LoginEndpointMap();

app.Run();