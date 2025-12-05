using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITeamService
{
    IEnumerable<TeamDto> GetAllTeams(bool trackChanges);
    TeamDto GetTeam(Guid teamId, bool trackChanges);
    TeamDto CreateTeam(NewTeamDto team);
}
