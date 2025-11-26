using Microsoft.EntityFrameworkCore;
using MovieManager.api.Entities;

namespace MovieManager.api.Data;


public class MovieManagerContext : DbContext
{
    public MovieManagerContext(DbContextOptions<MovieManagerContext> options) : base(options)
    {
    }

    public DbSet<Movies> Movie => Set<Movies>();
}