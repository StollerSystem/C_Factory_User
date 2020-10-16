using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {      
      this.Engineers = new HashSet<MachineEngineer>();
      this.Incidents = new HashSet<IncidentJoin>();
          
    }
    public int MachineId { get; set; }
    public string MachineName { get; set; }    
    public string MachineStatus { get; set; } 
    public string InspectionDate { get; set; } 
    public virtual ICollection<MachineEngineer> Engineers { get; set; }
    public virtual ICollection<IncidentJoin> Incidents { get; set; }
  }
}