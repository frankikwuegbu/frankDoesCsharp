using Entities.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

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

    public static IQueryable<Player> Sort(this IQueryable<Player> players, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return players.OrderBy(p => p.Name);

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(Player).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison
                .InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";

            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        if (string.IsNullOrWhiteSpace(orderQuery))
            return players.OrderBy(p => p.Name);

        return players.OrderBy(orderQuery);
    }
}
