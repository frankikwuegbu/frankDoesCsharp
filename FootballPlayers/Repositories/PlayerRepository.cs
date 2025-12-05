using Entities.Models;
using Contracts;
namespace Repositories;

public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
{
    public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Player> GetPlayers(Guid teamId, bool trackChanges) =>
        FindByCondition(p => p.TeamId.Equals(teamId), trackChanges)
        .OrderBy(p => p.Name).ToList();

    public Player GetPlayer(Guid teamId, Guid id, bool trackChanges) =>
        FindByCondition(p => p.TeamId.Equals(teamId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreatePlayer(Guid teamId, Player player)
    {
        player.TeamId = teamId;
        Create(player);
    }

    public void DeletePlayer(Player player) => Delete(player);
}
