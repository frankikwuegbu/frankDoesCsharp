using MovieManager.api.Entities;

const string GetMoviesEndpoint = "GetMovies";

List<Movies> movies = new()
{
    new Movies()
    {
        Id = 1,
        Title = "Speed",
        Genre = "action",
        ReleaseYear = 1994,
        ImageUrl = "image.url"
    },

    new Movies()
    {
        Id = 2,
        Title = "Letters to Juliet",
        Genre = "Romance",
        ReleaseYear = 2010,
        ImageUrl = "image.url"
    },

    new Movies()
    {
        Id = 3,
        Title = "The Lost Bus",
        Genre = "Docudrama",
        ReleaseYear = 2025,
        ImageUrl = "image.url"
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/movies").WithParameterValidation();

group.MapGet("/", () => movies);

group.MapGet("/{id}", (int id) =>
{
    Movies? movie = movies.Find(movie => movie.Id == id);

    if (movie == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(movie);
})
.WithName(GetMoviesEndpoint);

group.MapPost("/", (Movies movie) =>
{
    movie.Id = movies.Max(movie => movie.Id) + 1;
    movies.Add(movie);

    return Results.CreatedAtRoute(GetMoviesEndpoint, new { id = movie.Id }, movie);
});

group.MapPut("/{id}", (int id, Movies updatedMovie) =>
{
    Movies? existingMovie = movies.Find(existingMovie => existingMovie.Id == id);

    if (existingMovie == null)
    {
        Results.NotFound();
    }

    existingMovie.Title = updatedMovie.Title;
    existingMovie.Genre = updatedMovie.Genre;
    existingMovie.ReleaseYear = updatedMovie.ReleaseYear;

    return Results.NoContent();
});

group.MapDelete("/{id}", (int id) =>
{
    Movies? movie = movies.Find(movie => movie.Id == id);

    if (movie != null)
    {
        movies.Remove(movie);
    }

    return Results.NoContent();
});

app.Run();
