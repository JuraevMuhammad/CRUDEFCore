using System.Net;
using Domain.Dto.Hackathon;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class HackathonController(IHackathonService service) : ControllerBase
{
    [HttpPost]
    public IActionResult CreatedHackathon(CreatedHackathon created)
    {
        var result = service.CreatedHackathon(created);
        return StatusCode(result.StatusCode, result);
    }

    [HttpPut]
    public IActionResult UpdatedHackathon(int id, UpdatedHackathon updated)
    {
        var result = service.UpdatedHackathon(id, updated);
        return StatusCode(result.StatusCode, result);
    }

    [HttpDelete]
    public IActionResult DeletedHackathon(int id)
    {
        var result = service.DeleteHackathon(id);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet]
    public IActionResult GetHackathonById(int id)
    {
        var result = service.GetHackathonById(id);
        return StatusCode(result.StatusCode, result);
    }

    [HttpGet("all")]
    public IActionResult GetAllHackathons()
    {
        var res = service.GetHackathons();
        return StatusCode(res.StatusCode, res);
    }
}