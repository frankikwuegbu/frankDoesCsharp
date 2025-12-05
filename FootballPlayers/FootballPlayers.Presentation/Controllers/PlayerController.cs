using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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

    [HttpGet("{id:guid}")]
    public IActionResult GetPlayerForTeam(Guid teamId, Guid id)
    {
        var player = _service.PlayerService.GetPlayer(teamId, id, trackChanges: false);
        return Ok(player);
    }
}
