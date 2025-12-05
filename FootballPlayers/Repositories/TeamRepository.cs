using Contracts;
using Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories;

public class TeamRepository : RepositoryBase<Team>, ITeamRepository
{
    public TeamRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    public IEnumerable<Team> GetAllTeams(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(t => t.Name)
        .ToList();

    public Team GetTeam(Guid teamId, bool trackChanges) =>
        FindByCondition(t => t.Id.Equals(teamId), trackChanges)
        .SingleOrDefault();

    public void CreateTeam(Team team) => Create(team);

    public IEnumerable<Team> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(x => ids.Contains(x.Id), trackChanges)
        .ToList();

    public void DeleteTeam(Team team) => Delete(team);
}
