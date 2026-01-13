using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Hackathon> Hackathons { get; set; }
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Team> Teams { get; set; }
}
