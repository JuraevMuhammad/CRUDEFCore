using Domain.Dto.Participant;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class ParticipantController(IParticipantService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllParticipants()
    {
        var participants = service.GetAllParticipants();
        return StatusCode(participants.StatusCode, participants);
    }

    [HttpPut]
    public IActionResult UpdateParticipant(int id, UpdateParticipant dto)
    {
        var res = service.UpdateParticipant(id, dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpPost]
    public IActionResult CreatedParticipant(CreatedParticipant dto)
    {
        var res = service.CreatedParticipant(dto);
        return StatusCode(res.StatusCode, res);
    }

    [HttpDelete]
    public IActionResult DeleteParticipant(int id)
    {
        var res = service.DeleteParticipant(id);
        return StatusCode(res.StatusCode, res);
    }
}