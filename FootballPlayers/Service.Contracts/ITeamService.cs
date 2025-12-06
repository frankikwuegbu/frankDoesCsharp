using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITeamService
{
    IEnumerable<TeamDto> GetAllTeams(bool trackChanges);
    TeamDto GetTeam(Guid teamId, bool trackChanges);
    TeamDto CreateTeam(NewTeamDto team);
    IEnumerable<TeamDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<TeamDto> teams, string ids) CreateTeamCollection
        (IEnumerable<NewTeamDto> teamCollection);
    void DeleteTeam(Guid teamId, bool trackChanges);
    void UpdateTeam(Guid teamid, TeamUpdateDto updatedTeam, bool trackChanges);
}