namespace Domain.Dto.Participant;

public class CreatedParticipant
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; }  = string.Empty;
    public int TeamId { get; set; }
    public string Role { get; set; } = string.Empty;
    public DateTime JoinedDate { get; set; }
}