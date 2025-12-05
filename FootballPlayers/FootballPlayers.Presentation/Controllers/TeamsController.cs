using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace FootballPlayers.Presentation.Controllers;

[Route("api/teams")]
[ApiController]
public class TeamsController : ControllerBase
{
    private readonly IServiceManager _service;
    public TeamsController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetTeams()
    {
        var teams = _service.TeamService.GetAllTeams(trackChanges: false);
        return Ok(teams);
    }

    [HttpGet("{id:guid}", Name = "TeamById")]
    public IActionResult GetTeam(Guid id)
    {
        var team = _service.TeamService.GetTeam(id, trackChanges: false);
        return Ok(team);
    }

    [HttpPost]
    public IActionResult CreateTeam([FromBody] NewTeamDto team)
    {
        if (team is null)
            return BadRequest("NewTeamDto object is null");

        var newTeam = _service.TeamService.CreateTeam(team);
        return CreatedAtRoute("TeamById", new { id = newTeam.Id }, newTeam);
    }
}
