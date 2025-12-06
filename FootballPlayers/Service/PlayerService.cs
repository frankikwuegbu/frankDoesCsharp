using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
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
            throw new PlayerNotFoundException(id);

        var player = _mapper.Map<PlayerDto>(playerDb);
        return player;
    }

    public PlayerDto CreatePlayer(Guid teamId, CreatePlayerDto createPlayer, bool trackChanges)
    {
        var team = _repository.Team.GetTeam(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerEntity = _mapper.Map<Player>(createPlayer);

        _repository.Player.CreatePlayer(teamId, playerEntity);
        _repository.Save();

        var playerToReturn = _mapper.Map<PlayerDto>(playerEntity);

        return playerToReturn;
    }

    public void DeletePlayer(Guid teamId, Guid id, bool trackChanges)
    {
        var team = _repository.Team.GetTeam(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerForTeam = _repository.Player.GetPlayer(teamId, id, trackChanges);
        if (playerForTeam is null)
            throw new PlayerNotFoundException(id);

        _repository.Player.DeletePlayer(playerForTeam);
        _repository.Save();
    }

    public void UpdatePlayer(Guid teamId, Guid id, PlayerUpdateDto updatedPlayer,
        bool compTrackChanges, bool empTrackChanges)
    {
        var team = _repository.Team.GetTeam(teamId, compTrackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerEntity = _repository.Player.GetPlayer(teamId, id, empTrackChanges);
        if (playerEntity is null)
            throw new PlayerNotFoundException(id);
        _mapper.Map(updatedPlayer, playerEntity);
        _repository.Save();
    }

    public (PlayerUpdateDto playerToPatch, Player playerEntity)
    GetPlayerForPatch
        (Guid teamId, Guid id, bool compTrackChanges, bool empTrackChanges)
    {
        var team = _repository.Team.GetTeam(teamId, compTrackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerEntity = _repository.Player.GetPlayer(teamId, id, empTrackChanges);
        if (playerEntity is null)
            throw new PlayerNotFoundException(teamId);

        var playerToPatch = _mapper.Map<PlayerUpdateDto>(playerEntity);

        return (playerToPatch, playerEntity);
    }

    public void SaveChangesForPatch(PlayerUpdateDto playerToPatch, Player playerEntity)
    {
        _mapper.Map(playerToPatch, playerEntity);
        _repository.Save();
    }
}
