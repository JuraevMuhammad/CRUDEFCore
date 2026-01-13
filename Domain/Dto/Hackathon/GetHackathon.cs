using Domain.Dto.Team;

namespace Domain.Dto.Hackathon;

public class GetHackathon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Theme { get; set; } = string.Empty;
    public List<GetTeam>? Teams { get; set; }
}