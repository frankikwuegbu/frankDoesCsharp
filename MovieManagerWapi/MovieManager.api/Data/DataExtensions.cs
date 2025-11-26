using Microsoft.EntityFrameworkCore;
using MovieManager.api.Repositories;

namespace MovieManager.api.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MovieManagerContext>();
        await dbContext.Database.MigrateAsync();
    }

    //adds entity framework movie manager repository to program
    public static IServiceCollection AddRepository(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("MovieManagerContext");
        services.AddSqlServer<MovieManagerContext>(connectionString)
                .AddScoped<IMoviesRepository, EntityFrameworkMovieManagerRepository>();

        return services;
    }
}