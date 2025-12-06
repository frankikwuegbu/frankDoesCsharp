using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FootballPlayers.Presentation.Controllers;

[Route("api/teams/{teamId}/players")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IServiceManager _service;
    public PlayerController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetPlayersForTeam(Guid teamId)
    {
        var players = _service.PlayerService.GetPlayers(teamId, trackChanges: false);
        return Ok(players);
    }

    [HttpGet("{id:guid}", Name = "GetPlayer")]
    public IActionResult GetPlayer(Guid teamId, Guid id)
    {
        var player = _service.PlayerService.GetPlayer(teamId, id, trackChanges: false);
        return Ok(player);
    }

    [HttpPost]
    public IActionResult CreatePlayer(Guid teamId, [FromBody] CreatePlayerDto player)
    {
        if (player is null)
            return BadRequest("CreatePlayerDto object is null");

        var playerToReturn =
            _service.PlayerService.CreatePlayer(teamId, player, trackChanges: false);

        return CreatedAtRoute("GetPlayer", new
        {
            teamId,
            id = playerToReturn.Id
        },
            playerToReturn);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePlayer(Guid teamId, Guid id)
    {
        _service.PlayerService.DeletePlayer(teamId, id, trackChanges: false);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdatePlayer(Guid teamId, Guid id, [FromBody] PlayerUpdateDto player)
    {
        if (player is null)
            return BadRequest("PLayerUpdateDto object is null");
        _service.PlayerService.UpdatePlayer(teamId, id, player,
                compTrackChanges: false, empTrackChanges: true);

        return NoContent();
    }
}
