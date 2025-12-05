using Entities.Models;

namespace Contracts;

public interface ITeamRepository
{
    IEnumerable<Team> GetAllTeams(bool trackChanges);
    Team GetTeam(Guid teamId, bool trackChanges);
    void CreateTeam(Team team);
}
