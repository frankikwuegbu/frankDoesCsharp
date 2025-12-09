using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using static Service.TeamService;

namespace Service;

internal sealed class TeamService : ITeamService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public TeamService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    private async Task<Team> GetTeamAndCheckExistence(Guid id, bool trackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(id, trackChanges);

        if (team is null)
            throw new TeamNotFoundException(id);
        return team;
    }

    public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync(bool trackChanges)
    {
        var teams = await _repository.Team.GetAllTeamsAsync(trackChanges);
        var teamDto = _mapper.Map<IEnumerable<TeamDto>>(teams);
        return teamDto;
    }
    public async Task<TeamDto> GetTeamAsync(Guid id, bool trackChanges)
    {
        var team = await GetTeamAndCheckExistence(id, trackChanges);

        var teamDto = _mapper.Map<TeamDto>(team);
        return teamDto;
    }

    public async Task<TeamDto> CreateTeamAsync(NewTeamDto team)
    {
        var teamEntity = _mapper.Map<Team>(team);
        _repository.Team.CreateTeam(teamEntity);
        await _repository.SaveAsync();
        var teamToReturn = _mapper.Map<TeamDto>(teamEntity);
        return teamToReturn;
    }

    public async Task<IEnumerable<TeamDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();
        var teamEntities = await _repository.Team.GetByIdsAsync(ids, trackChanges);
        if (ids.Count() != teamEntities.Count())
            throw new CollectionByIdsBadRequestException();
        var teamsToReturn = _mapper.Map<IEnumerable<TeamDto>>(teamEntities);
        return teamsToReturn;
    }

    public async Task<(IEnumerable<TeamDto> teams, string ids)> CreateTeamCollectionAsync
        (IEnumerable<NewTeamDto> teamCollection)
    {
        if (teamCollection is null)
            throw new TeamCollectionBadRequest();

        var teamEntities = _mapper.Map<IEnumerable<Team>>(teamCollection);
        foreach (var team in teamEntities)
        {
            _repository.Team.CreateTeam(team);
        }

        await _repository.SaveAsync();

        var teamCollectionToReturn =
       _mapper.Map<IEnumerable<TeamDto>>(teamEntities);
        var ids = string.Join(",", teamCollectionToReturn.Select(t => t.Id));

        return (teams: teamCollectionToReturn, ids: ids);
    }

    public async Task DeleteTeamAsync(Guid teamId, bool trackChanges)
    {
        var team = await GetTeamAndCheckExistence(teamId, trackChanges);
        _repository.Team.DeleteTeam(team);
        await _repository.SaveAsync();
    }

    public async Task UpdateTeamAsync(Guid teamId, TeamUpdateDto updatedTeam, bool trackChanges)
    {
        var team = await GetTeamAndCheckExistence(teamId, trackChanges);

        _mapper.Map(updatedTeam, team);
        await _repository.SaveAsync();
    }
}
