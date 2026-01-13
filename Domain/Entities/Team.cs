namespace Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HackathonId { get; set; }
    public DateTime CreatedAt { get; set; } =  DateTime.Now;
    
    public Hackathon? Hackathon { get; set; }
    public List<Participant>? Participants { get; set; }
}