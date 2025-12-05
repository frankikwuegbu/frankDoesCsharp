using Entities.Models;

namespace Contracts;

public interface IPlayerRepository
{
    IEnumerable<Player> GetPlayers(Guid teamId, bool trackChanges);
    Player GetPlayer(Guid teamId, Guid id, bool trackChanges);
    void CreatePlayer(Guid teamId, Player player);
    void DeletePlayer(Player player);
}
