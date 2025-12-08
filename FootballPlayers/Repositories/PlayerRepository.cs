using Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
namespace Repositories;

public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
{
    public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Player>> GetPlayersAsync(Guid teamId, bool trackChanges) =>
        await FindByCondition(p => p.TeamId.Equals(teamId), trackChanges)
        .OrderBy(p => p.Name).ToListAsync();

    public async Task<Player> GetPlayerAsync(Guid teamId, Guid id, bool trackChanges) =>
        await FindByCondition(p => p.TeamId.Equals(teamId) && p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreatePlayer(Guid teamId, Player player)
    {
        player.TeamId = teamId;
        Create(player);
    }

    public void DeletePlayer(Player player) => Delete(player);
}
