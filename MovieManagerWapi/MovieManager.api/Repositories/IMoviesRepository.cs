using MovieManager.api.Entities;

namespace MovieManager.api.Repositories;

public interface IMoviesRepository
{
    void Create(Movies movie);
    void Delete(int id);
    Movies? Get(int id);
    IEnumerable<Movies> GetAll();
    void Update(Movies updatedMovie);
}
