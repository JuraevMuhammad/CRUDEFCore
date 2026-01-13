using System.Net;
using Domain.Dto.Hackathon;
using Domain.Dto.Team;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HackathonService(ApplicationDbContext context) : IHackathonService
{
    public Response<string> CreatedHackathon(CreatedHackathon dto)
    {
        var res = new Hackathon()
        {
            Name = dto.Name,
            Date = dto.Date,
            Theme = dto.Theme
        };
        context.Hackathons.Add(res);
        var effect = context.SaveChanges();
        return effect > 0
            ? new Response<string>(HttpStatusCode.Created, "Created Hackathon")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> UpdatedHackathon(int id, UpdatedHackathon dto)
    {
        var result = context.Hackathons.FirstOrDefault(x => x.Id == id);
        if (result == null)
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        result.Name = dto.Name ?? result.Name;
        result.Date = dto.Date ?? result.Date; 
        var res = context.SaveChanges();
        return res > 0
            ? new Response<string>(HttpStatusCode.NoContent, "Hackathon updated")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<string> DeleteHackathon(int id)
    {
        var res = context.Hackathons.FirstOrDefault(x => x.Id == id);
        if (res == null)
            return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        context.Hackathons.Remove(res);
        var result = context.SaveChanges();
        return result > 0
            ? new Response<string>(HttpStatusCode.NoContent, "Hackathon deleted")
            : new Response<string>(HttpStatusCode.BadRequest, "Error");
    }

    public Response<GetHackathon> GetHackathonById(int id)
    {
        var result = context.Hackathons.Include(x => x.Teams).Select(x => new GetHackathon()
        {
            Id = x.Id,
            Name = x.Name,
            Date = x.Date,
            Theme = x.Theme,
            
            Teams = x.Teams!.Select(t => new GetTeam()
            {
                Id = t.Id,
                Name = t.Name,
                HackathonId = t.HackathonId,
                CreatedAt = t.CreatedAt,
            }).ToList()
            
        }).FirstOrDefault(x => x.Id == id);
        
        return result == null
            ? new Response<GetHackathon>(HttpStatusCode.NotFound, "Not Found")
            : new Response<GetHackathon>(result);
    }

    public Response<List<GetHackathon>> GetHackathons()
    {
        var result = context.Hackathons.Include(x => x.Teams)
            .Select(h => new GetHackathon()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Date = h.Date,
                    Theme = h.Theme,
                    Teams = h.Teams!.Select(t => new GetTeam()
                        {
                            Id = t.Id,
                            Name = t.Name,
                            HackathonId = t.HackathonId,
                            CreatedAt = t.CreatedAt,
                        }
                    ).ToList()
                }
            ).ToList();
        return result.Count == 0
            ? new Response<List<GetHackathon>>(HttpStatusCode.NotFound, "Not Found")
            : new Response<List<GetHackathon>>(result);
    }
}