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
    public IEnumerable<Movies> GetAll()
    {
        return movies;
    }

    //returns a single movie
    public Movies? Get(int id)
    {
        return movies.Find(movie => movie.Id == id);
    }

    //add new movie
    public void Create(Movies movie)
    {
        movie.Id = movies.Max(movie => movie.Id) + 1;
        movies.Add(movie);
    }

    //update movie at index
    public void Update(Movies updatedMovie)
    {
        var index = movies.FindIndex(movie => movie.Id == updatedMovie.Id);
        movies[index] = updatedMovie;
    }

    //delete movie at index
    public void Delete(int id)
    {
        var index = movies.FindIndex(movie => movie.Id == id);
        movies.RemoveAt(index);
    }
}