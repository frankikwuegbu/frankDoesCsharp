using System.ComponentModel.DataAnnotations;

namespace MovieManager.api.dto;

public record MoviesDto(
    int Id,
    string Title,
    string Genre,
    int ReleaseYear,
    string ImageUrl
);
public record CreateMoviesDto(
    [Required][StringLength(50)] string Title,
    [Required][StringLength(50)] string Genre,
    [Range(1990, 2025)] int ReleaseYear,
    [Url][StringLength(100)] string ImageUrl
);
public record UpdateMoviesDto(
    [Required][StringLength(50)] string Title,
    [Required][StringLength(50)] string Genre,
    [Range(1990, 2025)] int ReleaseYear,
    [Url][StringLength(100)] string ImageUrl
);