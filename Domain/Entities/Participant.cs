namespace Domain.Entities;

public class Participant
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public int TeamId { get; set; }
    public string Role { get; set; } = string.Empty;
    public DateTime JoinedDate { get; set; }
    
    public Team? Team { get; set; }
}