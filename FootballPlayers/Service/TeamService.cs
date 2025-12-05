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
}
