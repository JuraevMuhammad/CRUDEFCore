using Domain.Dto.Hackathon;
using Domain.Response;

namespace Infrastructure.Interfaces;

public interface IHackathonService
{
    Response<string> CreatedHackathon(CreatedHackathon dto);
    Response<string> UpdatedHackathon(int id, UpdatedHackathon dto);
    Response<string> DeleteHackathon(int id);
    Response<GetHackathon> GetHackathonById(int id);
    Response<List<GetHackathon>> GetHackathons();
}