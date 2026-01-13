using System.Net;
using Domain.Dto.Participant;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ParticipantService(ApplicationDbContext context) : IParticipantService
{
    public Response<List<GetParticipant>> GetAllParticipants()
    {
        var participants = context.Participants.Select(x => new GetParticipant()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Role = x.Role,
                TeamId = x.TeamId,
                JoinedDate = x.JoinedDate
            }
        ).ToList();
        return participants.Count > 0
            ? new Response<List<GetParticipant>>(participants)
            : new Response<List<GetParticipant>>(HttpStatusCode.NotFound, "0 Participant");
    }

    public Response<string> CreatedParticipant(CreatedParticipant dto)
    {
        var createdDto = new Participant()
        {
            Email = dto.Email,
            Role = dto.Role,
            Name = dto.Name,
            TeamId = dto.TeamId,
            JoinedDate = dto.JoinedDate
        };
        context.Participants.Add(createdDto);
        var res = context.SaveChanges();
        return new Response<string>(HttpStatusCode.Created, "Created Participant");
    }

    public Response<string> UpdateParticipant(int id, UpdateParticipant dto)
    {
        var participant = context.Participants.FirstOrDefault(x => x.Id == id);
        if (participant == null)
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        participant.Name = dto.Name ?? participant.Name;
        participant.Email = dto.Email ??  participant.Email;
        context.SaveChanges();
        return new Response<string>(HttpStatusCode.OK, "Updated Participant");
    }

    public Response<string> DeleteParticipant(int id)
    {
        var participant = context.Participants.FirstOrDefault(x => x.Id == id);
        if (participant == null)
            return new Response<string>(HttpStatusCode.NotFound, "Participant not found");
        context.Participants.Remove(participant);
        context.SaveChanges();
        return new Response<string>(HttpStatusCode.OK, "Deleted Participant");
    }
}