using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class PlayerService : IPlayerService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public PlayerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
    public IEnumerable<PlayerDto> GetPlayers(Guid teamId, bool trackChanges)
    {
        var team = _repository.Team.GetTeam(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);
        var playersfromDb = _repository.Player.GetPlayers(teamId, trackChanges);

        var playerDto = _mapper.Map<IEnumerable<PlayerDto>>(playersfromDb);
        return playerDto;
    }
    public PlayerDto GetPlayer(Guid teamId, Guid id, bool trackChanges)
    {
        var team = _repository.Team.GetTeam(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerDb = _repository.Player.GetPlayer(teamId, id, trackChanges);
        if (playerDb is null)
            throw new PlayerNotFoundExcetption(id);

        var player = _mapper.Map<PlayerDto>(playerDb);
        return player;
    }
}
