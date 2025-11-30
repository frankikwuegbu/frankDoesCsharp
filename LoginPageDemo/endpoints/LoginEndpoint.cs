using LoginPageDemo.repositories;

namespace LoginPageDemo.entities.endpoints;

public static class LoginEndpoint
{
    public static RouteGroupBuilder LoginEndpointMap(this IEndpointRouteBuilder route)
    {
        //naming GetUser endpoint
        const string GetUserEndpoint = "GetUser";
        //using route group
        var group = route.MapGroup("/users").WithParameterValidation();

        //get all users
        group.MapGet("/", (IUserRepository repository) =>
            repository.GetAllUsers().Select(user => user.GetDto()));//we use the select operator to get the dto version of every user

        //get user by username - login
        group.MapGet("/{username}", (IUserRepository repository, string username) =>
        {
            User? user = repository.GetUser(username);

            if (user is not null)
            {
                return Results.Ok(user.GetDto());
            }
            return Results.NotFound();
        }
        ).WithName(GetUserEndpoint);

        //create user - sign up
        group.MapPost("/", (IUserRepository repository, CreateUserDto createdUserDto) =>
        {
            //map the user entity to its dto equivalent
            User user = new()
            {
                Name = createdUserDto.Name,
                UserName = createdUserDto.UserName,
                Password = createdUserDto.Password,
                ConfirmPassword = createdUserDto.ConfirmPassword
            };

            repository.CreateUser(user);

            return Results.CreatedAtRoute(GetUserEndpoint, new { username = user.UserName }, user);
        });
        return group;
    }
}