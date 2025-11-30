using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace LoginPageDemo.entities;

public static class UserExtensionMethods
{
    public static UserDto GetDto(this User user)
    {
        return new UserDto(
            user.Id,
            user.Name,
            user.UserName
        );
    }
}