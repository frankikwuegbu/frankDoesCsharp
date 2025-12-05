using FootballPlayers.Presentation.ModelBinders;
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

    [HttpGet("collection/({ids})", Name = "TeamCollection")]
    public IActionResult GetTeamCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)

    {
        var teams = _service.TeamService.GetByIds(ids, trackChanges: false);

        return Ok(teams);
    }

    [HttpPost("collection")]
    public IActionResult CreateTeamCollection([FromBody]
        IEnumerable<NewTeamDto> teamCollection)
    {
        var result = _service.TeamService.CreateTeamCollection(teamCollection);

        return CreatedAtRoute("TeamCollection", new { result.ids }, result.teams);
    }
}
