using System.Text.RegularExpressions;
using MovieManager.api.dto;
using MovieManager.api.Entities;
using MovieManager.api.Repositories;

namespace MovieManager.api.Endpoints;

public static class MoviesEndpoints
{
    const string GetMoviesEndpoint = "GetMovies";

    public static RouteGroupBuilder MapMoviesEndpoint(this IEndpointRouteBuilder route)
    {
        var group = route.MapGroup("/movies").WithParameterValidation();

        //get all movies on list
        group.MapGet("/", async (IMoviesRepository repository)
                    => (await repository.GetAllAsync()).Select(movie => movie.AsDto()));

        //get single movie by id
        group.MapGet("/{id}", async (IMoviesRepository repository, int id) =>
        {
            Movies? movie = await repository.GetAsync(id);

            return movie is not null ? Results.Ok(movie.AsDto()) : Results.NotFound();
        })
        .WithName(GetMoviesEndpoint);

        //add new movie to list
        group.MapPost("/", async (IMoviesRepository repository, CreateMoviesDto movieDto) =>
        {
            Movies movie = new Movies()
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseYear = movieDto.ReleaseYear,
                ImageUrl = movieDto.ImageUrl
            };
            await repository.CreateAsyn(movie);

            return Results.CreatedAtRoute(GetMoviesEndpoint, new { id = movie.Id }, movie);
        });

        //update existing movie
        group.MapPut("/{id}", async (IMoviesRepository repository, int id, UpdateMoviesDto updatedMovieDto) =>
        {
            Movies? existingMovie = await repository.GetAsync(id);

            if (existingMovie == null)
            {
                Results.NotFound();
            }

            existingMovie.Title = updatedMovieDto.Title;
            existingMovie.Genre = updatedMovieDto.Genre;
            existingMovie.ReleaseYear = updatedMovieDto.ReleaseYear;

            await repository.UpdateAsync(existingMovie);

            return Results.NoContent();
        });

        //delete movie
        group.MapDelete("/{id}", async (IMoviesRepository repository, int id) =>
        {
            Movies? movie = await repository.GetAsync(id);

            if (movie != null)
            {
                await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}