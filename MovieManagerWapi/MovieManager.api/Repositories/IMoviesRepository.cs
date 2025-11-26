using MovieManager.api.Entities;

namespace MovieManager.api.Repositories;

public interface IMoviesRepository
{
    Task CreateAsyn(Movies movie);
    Task DeleteAsync(int id);
    Task<Movies?> GetAsync(int id);
    Task<IEnumerable<Movies>> GetAllAsync();
    Task UpdateAsync(Movies updatedMovie);
}
