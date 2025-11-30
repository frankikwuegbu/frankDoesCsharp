using System.ComponentModel.DataAnnotations;

namespace LoginPageDemo.entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string UserName { get; set; }
    [Required][StringLength(20, MinimumLength =8)]
    public required string Password { get; set; }
    [Required][Compare("Password")]
    public required string ConfirmPassword { get; set; }
}