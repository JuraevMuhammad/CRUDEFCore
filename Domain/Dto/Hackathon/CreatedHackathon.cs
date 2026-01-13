namespace Domain.Dto.Hackathon;

public class CreatedHackathon
{
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Today;
    public string Theme { get; set; } = string.Empty;
}