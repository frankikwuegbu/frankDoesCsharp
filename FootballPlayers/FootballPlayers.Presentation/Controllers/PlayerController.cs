using Entities.Exceptions;
using FootballPlayers.Presentation.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace FootballPlayers.Presentation.Controllers;

[Route("api/teams/{teamId}/players")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IServiceManager _service;
    public PlayerController(IServiceManager service) => _service = service;

    [HttpGet]
    [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
    public async Task<IActionResult> GetPlayersForTeam(Guid teamId, [FromQuery] PlayerParameters playerParameters)
    {
        if (!playerParameters.ValidAgeRange)
            throw new MaxAgeRangeBadRequestException();

        var players = await _service.PlayerService.GetPlayersAsync(teamId, playerParameters, trackChanges: false);
        return Ok(players);
    }

    [HttpGet("{id:guid}", Name = "GetPlayer")]
    public async Task<IActionResult> GetPlayer(Guid teamId, Guid id)
    {
        var player = await _service.PlayerService.GetPlayerAsync(teamId, id, trackChanges: false);
        return Ok(player);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePlayer(Guid teamId, [FromBody] CreatePlayerDto player)
    {
        var playerToReturn =
            await _service.PlayerService.CreatePlayerAsync(teamId, player, trackChanges: false);

        return CreatedAtRoute("GetPlayer", new
        {
            teamId,
            id = playerToReturn.Id
        },
            playerToReturn);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePlayer(Guid teamId, Guid id)
    {
        await _service.PlayerService.DeletePlayerAsync(teamId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdatePlayer(Guid teamId, Guid id, [FromBody] PlayerUpdateDto player)
    {
        await _service.PlayerService.UpdatePlayerAsync(teamId, id, player,
                compTrackChanges: false, empTrackChanges: true);

        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdatePlayerForTeam(Guid teamId, Guid id,
        [FromBody] JsonPatchDocument<PlayerUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object sent from client is null.");
        var result = await _service.PlayerService.GetPlayerForPatchAsync(teamId, id,
        compTrackChanges: false,
        empTrackChanges: true);
        patchDoc.ApplyTo(result.playerToPatch);
        //patchDoc.ApplyTo(playerToPatch, ModelState);
        await _service.PlayerService.SaveChangesForPatchAsync(result.playerToPatch,
            result.playerEntity);
        return NoContent();
    }
}
