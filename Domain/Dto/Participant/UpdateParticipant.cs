namespace Domain.Dto.Participant;

public class UpdateParticipant
{
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; }  = string.Empty;
    public string? Role { get; set; } = string.Empty;
}