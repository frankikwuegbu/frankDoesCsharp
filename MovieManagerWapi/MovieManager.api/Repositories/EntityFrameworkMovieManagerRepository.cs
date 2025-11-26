using Microsoft.EntityFrameworkCore;
using MovieManager.api.Data;
using MovieManager.api.Entities;

namespace MovieManager.api.Repositories;

public class EntityFrameworkMovieManagerRepository : IMoviesRepository
{
    private readonly MovieManagerContext dbContext;

    public EntityFrameworkMovieManagerRepository(MovieManagerContext dbContext)
    {
        this.dbContext = dbContext;
    }

    //gets all movies
    public async Task<IEnumerable<Movies>> GetAllAsync()
    {
        return await dbContext.Movie.AsNoTracking().ToListAsync();
    }
    public async Task<Movies?> GetAsync(int id)
    {
        return await dbContext.Movie.FindAsync(id);
    }
    public async Task CreateAsyn(Movies movie)
    {
        dbContext.Movie.Add(movie);
        await dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Movies updatedMovie)
    {
        dbContext.Update(updatedMovie);
        await dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        await dbContext.Movie.Where(movie => movie.Id == id)
                        .ExecuteDeleteAsync();
    }
}