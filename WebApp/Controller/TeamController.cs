using Domain.Dto.Team;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class TeamController(ITeamService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreatedTeam(CreatedTeam dto)
    {
        var res = service.CreatedTeam(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet]
    public IActionResult GetAllTeam()
    {
        var res = service.GetAllTeams();
        return StatusCode(res.StatusCode, res);
    }

    [HttpGet("id")]
    public IActionResult GetTeam(int id)
    {
        var res = service.GetTeam(id);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPut]
    public IActionResult UpdateTeam(int id, UpdateTeam dto)
    {
        var res = service.UpdateTeam(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteTeam(int id)
    {
        var res = service.DeleteTeam(id);
        return StatusCode(res.StatusCode, res);
    }
}