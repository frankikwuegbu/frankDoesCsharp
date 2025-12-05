using Entities.Models;

namespace Contracts;

public interface ITeamRepository
{
    IEnumerable<Team> GetAllTeams(bool trackChanges);
    Team GetTeam(Guid teamId, bool trackChanges);
    void CreateTeam(Team team);
    IEnumerable<Team> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    void DeleteTeam(Team team);
}
