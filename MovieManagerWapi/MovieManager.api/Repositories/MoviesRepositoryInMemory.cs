using MovieManager.api.Entities;

namespace MovieManager.api.Repositories;

public class MoviesRepositoryInMemory : IMoviesRepository
{
    private readonly List<Movies> movies = new()
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

    //returns all movies in the list
    public async Task<IEnumerable<Movies>> GetAllAsync()
    {
        return await Task.FromResult(movies);
    }

    //returns a single movie
    public async Task<Movies?> GetAsync(int id)
    {
        return await Task.FromResult(movies.Find(movie => movie.Id == id));
    }

    //add new movie
    public async Task CreateAsyn(Movies movie)
    {
        movie.Id = movies.Max(movie => movie.Id) + 1;
        movies.Add(movie);

        await Task.CompletedTask;
    }

    //update movie at index
    public async Task UpdateAsync(Movies updatedMovie)
    {
        var index = movies.FindIndex(movie => movie.Id == updatedMovie.Id);
        movies[index] = updatedMovie;

        await Task.CompletedTask;
    }

    //delete movie at index
    public async Task DeleteAsync(int id)
    {
        var index = movies.FindIndex(movie => movie.Id == id);
        movies.RemoveAt(index);

        await Task.CompletedTask;
    }
}