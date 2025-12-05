using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<Player>? Players { get; set; }
    }
}
