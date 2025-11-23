using System.ComponentModel.DataAnnotations;

namespace MovieManager.api.Entities;

public class Movies
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Title { get; set; }

    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }

    [Range(1990, 2026)]
    public int ReleaseYear { get; set; }

    [Url]
    [StringLength(100)]
    public required string ImageUrl { get; set; }
    public bool Rented { get; set; } = false;
}