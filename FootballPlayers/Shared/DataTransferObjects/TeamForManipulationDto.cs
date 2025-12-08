using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record TeamForManipulationDto
{
    [Required(ErrorMessage = "Team name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Team country is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Country { get; init; }

    [Required(ErrorMessage = "Team city is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? City { get; init; }

    public IEnumerable<CreatePlayerDto>? Players { get; init; }
}