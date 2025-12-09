using Entities.Models;

namespace Repositories.Extensions;

public static class RepositoryPlayerExtensions
{
    public static IQueryable<Player> FilterPlayers(this IQueryable<Player> players, uint minAge, uint maxAge) =>
        players.Where(p => (p.Age >= minAge && p.Age <= maxAge));
    public static IQueryable<Player> Search(this IQueryable<Player> players, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return players;
        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return players.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
    }
}
