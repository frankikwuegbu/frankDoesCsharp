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
    public async Task<IActionResult> GetTeams()
    {
        var teams = await _service.TeamService.GetAllTeamsAsync(trackChanges: false);
        return Ok(teams);
    }

    [HttpGet("{id:guid}", Name = "TeamById")]
    public async Task<IActionResult> GetTeam(Guid id)
    {
        var team = await _service.TeamService.GetTeamAsync(id, trackChanges: false);
        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeam([FromBody] NewTeamDto team)
    {
        if (team is null)
            return BadRequest("NewTeamDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var newTeam = await _service.TeamService.CreateTeamAsync(team);
        return CreatedAtRoute("TeamById", new { id = newTeam.Id }, newTeam);
    }

    [HttpGet("collection/({ids})", Name = "TeamCollection")]
    public async Task<IActionResult> GetTeamCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)

    {
        var teams = await _service.TeamService.GetByIdsAsync(ids, trackChanges: false);

        return Ok(teams);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateTeamCollection([FromBody]
        IEnumerable<NewTeamDto> teamCollection)
    {
        var result = await _service.TeamService.CreateTeamCollectionAsync(teamCollection);

        return CreatedAtRoute("TeamCollection", new { result.ids }, result.teams);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        await _service.TeamService.DeleteTeamAsync(id, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTeam(Guid id, [FromBody] TeamUpdateDto team)
    {
        if (team is null)
            return BadRequest("TeamUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.TeamService.UpdateTeamAsync(id, team, trackChanges: true);

        return NoContent();
    }
}
