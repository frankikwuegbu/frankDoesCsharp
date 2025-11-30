using System.ComponentModel.DataAnnotations;

namespace LoginPageDemo;

public record UserDto(
    int Id,
    string Name,
    string UserName
);
public record CreateUserDto(
    [Required] string Name,
    [Required] string UserName,
    [Required][StringLength(20, MinimumLength =8)] string Password,
    [Required] string ConfirmPassword
);