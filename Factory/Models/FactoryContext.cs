using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
  public class FactoryContext : DbContext
  {
    public DbSet<Machine> Machines { get; set; }

    public DbSet<Engineer> Engineers { get; set; }

    public DbSet<Incident> Incidents { get; set; }

    public DbSet<MachineEngineer> MachineEngineers { get; set; }

    public DbSet<IncidentJoin> IncidentJoins { get; set; }    
    
    public FactoryContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}