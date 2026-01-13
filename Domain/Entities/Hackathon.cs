namespace Domain.Entities;

public class Hackathon
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Theme { get; set; } = string.Empty;
    
    public List<Team>? Teams { get; set; }
}