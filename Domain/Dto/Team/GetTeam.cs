using Domain.Dto.Participant;
namespace Domain.Dto.Team;

public class GetTeam
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HackathonId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<GetParticipant>? Participants { get; set; }
}