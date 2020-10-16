namespace Factory.Models
{
  public class IncidentJoin
  {
    public int IncidentJoinId { get; set; }
    public int IncidentId { get; set; }
    public int MachineId { get; set; }
    public int EngineerId { get; set; }
    public virtual Incident Incident { get; set; }
    public virtual Machine Machine { get; set; }
    public virtual Engineer Engineer { get; set; }
  }
}