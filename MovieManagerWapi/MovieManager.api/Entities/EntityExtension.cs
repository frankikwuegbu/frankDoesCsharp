using MovieManager.api.dto;

namespace MovieManager.api.Entities;

public static class EntityExtension
{
    public static MoviesDto AsDto(this Movies movie)
    {
        return new MoviesDto(
            movie.Id,
            movie.Title,
            movie.Genre,
            movie.ReleaseYear,
            movie.ImageUrl
        );
    }
}