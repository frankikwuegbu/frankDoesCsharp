using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

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
    public async Task<IEnumerable<PlayerDto>> GetPlayersAsync(Guid teamId, PlayerParameters playerParameters, bool trackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);
        var playersfromDb = await _repository.Player.GetPlayersAsync(teamId, playerParameters, trackChanges);

        var playerDto = _mapper.Map<IEnumerable<PlayerDto>>(playersfromDb);
        return playerDto;
    }
    public async Task<PlayerDto> GetPlayerAsync(Guid teamId, Guid id, bool trackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerDb = await _repository.Player.GetPlayerAsync(teamId, id, trackChanges);
        if (playerDb is null)
            throw new PlayerNotFoundException(id);

        var player = _mapper.Map<PlayerDto>(playerDb);
        return player;
    }

    public async Task<PlayerDto> CreatePlayerAsync(Guid teamId, CreatePlayerDto createPlayer, bool trackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerEntity = _mapper.Map<Player>(createPlayer);

        _repository.Player.CreatePlayer(teamId, playerEntity);
        await _repository.SaveAsync();

        var playerToReturn = _mapper.Map<PlayerDto>(playerEntity);

        return playerToReturn;
    }

    public async Task DeletePlayerAsync(Guid teamId, Guid id, bool trackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(teamId, trackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerForTeam = await _repository.Player.GetPlayerAsync(teamId, id, trackChanges);
        if (playerForTeam is null)
            throw new PlayerNotFoundException(id);

        _repository.Player.DeletePlayer(playerForTeam);
        await _repository.SaveAsync();
    }

    public async Task UpdatePlayerAsync(Guid teamId, Guid id, PlayerUpdateDto updatedPlayer,
        bool compTrackChanges, bool empTrackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(teamId, compTrackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerEntity = await _repository.Player.GetPlayerAsync(teamId, id, empTrackChanges);
        if (playerEntity is null)
            throw new PlayerNotFoundException(id);
        _mapper.Map(updatedPlayer, playerEntity);
        await _repository.SaveAsync();
    }

    public async Task<(PlayerUpdateDto playerToPatch, Player playerEntity)>
    GetPlayerForPatchAsync
        (Guid teamId, Guid id, bool compTrackChanges, bool empTrackChanges)
    {
        var team = await _repository.Team.GetTeamAsync(teamId, compTrackChanges);
        if (team is null)
            throw new TeamNotFoundException(teamId);

        var playerEntity = await _repository.Player.GetPlayerAsync(teamId, id, empTrackChanges);
        if (playerEntity is null)
            throw new PlayerNotFoundException(teamId);

        var playerToPatch = _mapper.Map<PlayerUpdateDto>(playerEntity);

        return (playerToPatch, playerEntity);
    }

    public async Task SaveChangesForPatchAsync(PlayerUpdateDto playerToPatch, Player playerEntity)
    {
        _mapper.Map(playerToPatch, playerEntity);
        await _repository.SaveAsync();
    }
}
