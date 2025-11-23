using System.Text.RegularExpressions;
using MovieManager.api.Entities;
using MovieManager.api.Repositories;

namespace MovieManager.api.Endpoints;

public static class MoviesEndpoints
{
    const string GetMoviesEndpoint = "GetMovies";

    public static RouteGroupBuilder MapMoviesEndpoint(this IEndpointRouteBuilder route)
    {
        MoviesRepository repository = new();

        var group = route.MapGroup("/movies").WithParameterValidation();

        //get all movies on list
        group.MapGet("/", () => repository.GetAll());

        //get single movie by id
        group.MapGet("/{id}", (int id) =>
        {
            Movies? movie = repository.Get(id);

            return movie is not null ? Results.Ok(movie) : Results.NotFound();
        })
        .WithName(GetMoviesEndpoint);

        //add new movie to list
        group.MapPost("/", (Movies movie) =>
        {
            repository.Create(movie);

            return Results.CreatedAtRoute(GetMoviesEndpoint, new { id = movie.Id }, movie);
        });

        //update existing movie
        group.MapPut("/{id}", (int id, Movies updatedMovie) =>
        {
            Movies? existingMovie = repository.Get(id);

            if (existingMovie == null)
            {
                Results.NotFound();
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.ReleaseYear = updatedMovie.ReleaseYear;

            repository.Update(existingMovie);

            return Results.NoContent();
        });

        //delete movie
        group.MapDelete("/{id}", (int id) =>
        {
            Movies? movie = repository.Get(id);

            if (movie != null)
            {
                repository.Delete(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}