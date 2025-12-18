using Entities.LinkModels;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IPlayerService
{
    Task<(LinkResponse linkResponse, IEnumerable<PlayerDto>)> GetPlayersAsync(Guid teamId, LinkParameters linkParameters, bool trackChanges);
    Task<PlayerDto> GetPlayerAsync(Guid teamId, Guid id, bool trackChanges);
    Task<PlayerDto> CreatePlayerAsync(Guid teamId, CreatePlayerDto createPlayer, bool trackChanges);
    Task DeletePlayerAsync(Guid teamId, Guid id, bool trackChanges);
    Task UpdatePlayerAsync(Guid teamId, Guid id,
        PlayerUpdateDto updatedPlayer, bool compTrackChanges, bool empTrackChanges);
    Task<(PlayerUpdateDto playerToPatch, Player playerEntity)> GetPlayerForPatchAsync(
            Guid teamId, Guid id, bool compTrackChanges, bool empTrackChanges);
    Task SaveChangesForPatchAsync(PlayerUpdateDto playerToPatch, Player playerEntity);
}
