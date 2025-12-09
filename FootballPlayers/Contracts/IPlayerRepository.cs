using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IPlayerRepository
{
    Task<IEnumerable<Player>> GetPlayersAsync(Guid teamId, PlayerParameters playerParameters, bool trackChanges);
    Task<Player> GetPlayerAsync(Guid teamId, Guid id, bool trackChanges);
    void CreatePlayer(Guid teamId, Player player);
    void DeletePlayer(Player player);
}
