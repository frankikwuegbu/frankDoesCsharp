using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Team
{
    [Column("TeamId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Team name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Team Country is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Country is 60 characters")]
    public string? Country { get; set; }

    public string? City { get; set; }

    public ICollection<Player>? Players { get; set; }
}
