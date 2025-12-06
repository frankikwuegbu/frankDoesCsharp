using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IPlayerService
{
    IEnumerable<PlayerDto> GetPlayers(Guid teamId, bool trackChanges);
    PlayerDto GetPlayer(Guid teamId, Guid id, bool trackChanges);
    PlayerDto CreatePlayer(Guid teamId, CreatePlayerDto createPlayer, bool trackChanges);
    void DeletePlayer(Guid teamId, Guid id, bool trackChanges);
    void UpdatePlayer(Guid teamId, Guid id,
        PlayerUpdateDto updatedPlayer, bool compTrackChanges, bool empTrackChanges);
}
