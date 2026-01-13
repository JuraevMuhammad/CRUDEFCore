using System.Net;
using Domain.Dto.Participant;
using Domain.Dto.Team;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(ApplicationDbContext context) : ITeamService
{
    public Response<List<GetTeam>> GetAllTeams()
    {
        var res = context.Teams.Include(x => x.Participants).Select(t => new GetTeam()
            {
                Id = t.Id,
                Name = t.Name,
                CreatedAt = t.CreatedAt,
                HackathonId = t.HackathonId,
                Participants = t.Participants!.Select(p => new GetParticipant()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Role = p.Role,
                        TeamId = p.TeamId,
                        Email = p.Email,
                        JoinedDate = p.JoinedDate
                    }
                ).ToList()
            }
        ).ToList();
        return res.Count > 0
            ? new Response<List<GetTeam>>(res)
            : new Response<List<GetTeam>>(HttpStatusCode.NotFound, "No teams found");
    }

    public Response<string> CreatedTeam(CreatedTeam dto)
    {
        var createdTeam = new Team()
        {
            Name = dto.Name,
            HackathonId = dto.HackathonId
        };
        context.Teams.Add(createdTeam);
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "Created Team")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> UpdateTeam(int id, UpdateTeam dto)
    {
        var team = context.Teams.FirstOrDefault(t => t.Id == id);
        if (team == null)
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        team.Name = dto.Name ?? team.Name;
        var res = context.SaveChanges();
        return res  > 0
            ? new Response<string>(HttpStatusCode.NoContent, "Team updated")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> DeleteTeam(int id)
    {
        var deleteTeam = context.Teams.FirstOrDefault(x => x.Id == id);
        if (deleteTeam == null)
            return new Response<string>(HttpStatusCode.NotFound, "Team not found");
        context.Teams.Remove(deleteTeam);
        var res = context.SaveChanges();
        return res  > 0
            ? new Response<string>(HttpStatusCode.NoContent, "Team deleted")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<GetTeam> GetTeam(int id)
    {
        var getTeam = context.Teams.Include(i => i.Participants)
            .Where(t => t.Id == id).Select(x => new GetTeam()
                {
                    Id = x.Id,
                    Name = x.Name,
                    HackathonId = x.HackathonId,
                    CreatedAt = x.CreatedAt,
                    Participants = x.Participants!.Select(p => new GetParticipant()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Role = p.Role,
                            TeamId = p.TeamId,
                            Email = p.Email,
                            JoinedDate = p.JoinedDate
                        }
                    ).ToList()
                }
            ).FirstOrDefault();
        return new Response<GetTeam>(getTeam);
    }
}