using MovieManager.api.Entities;

const string GetMoviesEndpointName = "GetMovies";

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

app.MapGet("/movies", () => movies);

app.MapGet("/movies/{id}", (int id) =>
{
    Movies? movie = movies.Find(movie => movie.Id == id);

    if (movie == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(movie);
})
.WithName(GetMoviesEndpointName);

app.MapPost("/movies", (Movies movie) =>
{
    movie.Id = movies.Max(movie => movie.Id) + 1;
    movies.Add(movie);

    return Results.CreatedAtRoute(GetMoviesEndpointName, new { id = movie.Id }, movie);
});

app.MapPut("/movies/{id}", (int id, Movies updatedMovie) =>
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

app.MapDelete("/movies/{id}", (int id) =>
{
    Movies? movie = movies.Find(movie => movie.Id == id);

    if (movie != null)
    {
        movies.Remove(movie);
    }

    return Results.NoContent();
});

app.Run();
