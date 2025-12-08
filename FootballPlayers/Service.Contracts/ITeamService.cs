using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITeamService
{
    Task<IEnumerable<TeamDto>> GetAllTeamsAsync(bool trackChanges);
    Task<TeamDto> GetTeamAsync(Guid teamId, bool trackChanges);
    Task<TeamDto> CreateTeamAsync(NewTeamDto team);
    Task<IEnumerable<TeamDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<TeamDto> teams, string ids)> CreateTeamCollectionAsync
        (IEnumerable<NewTeamDto> teamCollection);
    Task DeleteTeamAsync(Guid teamId, bool trackChanges);
    Task UpdateTeamAsync(Guid teamid, TeamUpdateDto updatedTeam, bool trackChanges);
}