using Entities.Models;

namespace Contracts;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllTeamsAsync(bool trackChanges);
    Task<Team> GetTeamAsync(Guid teamId, bool trackChanges);
    void CreateTeam(Team team);
    Task<IEnumerable<Team>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteTeam(Team team);
}
