using Domain.Dto.Team;
using Domain.Entities;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface ITeamService
{
    Response<List<GetTeam>> GetAllTeams();
    Response<string> CreatedTeam(CreatedTeam dto);
    Response<string> UpdateTeam(int id, UpdateTeam dto);
    Response<string> DeleteTeam(int id);
    Response<GetTeam> GetTeam(int id);
}