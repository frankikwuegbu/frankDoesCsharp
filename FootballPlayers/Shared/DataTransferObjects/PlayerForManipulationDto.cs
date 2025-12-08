using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record PlayerForManipulationDto
{
    [Required(ErrorMessage = "Player name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }

    [Range(15, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 15")]
    public int? Age { get; set; }

    [Required(ErrorMessage = "Player position is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the position is 30 characters.")]
    public string? Position { get; init; }
}
