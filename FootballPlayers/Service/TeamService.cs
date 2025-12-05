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
    public IEnumerable<TeamDto> GetAllTeams(bool trackChanges)
    {
        var teams = _repository.Team.GetAllTeams(trackChanges);
        var teamDto = _mapper.Map<IEnumerable<TeamDto>>(teams);
        return teamDto;
    }
    public TeamDto GetTeam(Guid id, bool trackChanges)
    {
        var team = _repository.Team.GetTeam(id, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(id);

        var teamDto = _mapper.Map<TeamDto>(team);
        return teamDto;
    }

    public TeamDto CreateTeam(NewTeamDto team)
    {
        var teamEntity = _mapper.Map<Team>(team);
        _repository.Team.CreateTeam(teamEntity);
        _repository.Save();
        var teamToReturn = _mapper.Map<TeamDto>(teamEntity);
        return teamToReturn;
    }

    public IEnumerable<TeamDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();
        var teamEntities = _repository.Team.GetByIds(ids, trackChanges);
        if (ids.Count() != teamEntities.Count())
            throw new CollectionByIdsBadRequestException();
        var teamsToReturn = _mapper.Map<IEnumerable<TeamDto>>(teamEntities);
        return teamsToReturn;
    }

    public (IEnumerable<TeamDto> teams, string ids) CreateTeamCollection
        (IEnumerable<NewTeamDto> teamCollection)
    {
        if (teamCollection is null)
            throw new TeamCollectionBadRequest();

        var teamEntities = _mapper.Map<IEnumerable<Team>>(teamCollection);
        foreach (var team in teamEntities)
        {
            _repository.Team.CreateTeam(team);
        }

        _repository.Save();

        var teamCollectionToReturn =
       _mapper.Map<IEnumerable<TeamDto>>(teamEntities);
        var ids = string.Join(",", teamCollectionToReturn.Select(t => t.Id));

        return (teams: teamCollectionToReturn, ids: ids);
    }
}
