using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {      
      this.Machines = new HashSet<MachineEngineer>();
      this.Incidents = new HashSet<IncidentJoin>();          
    }
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }    
    public string EngineerStatus { get; set; }
    public string LicenseRenewal { get; set; }  
    public virtual ApplicationUser User { get; set; } 
    public virtual ICollection<MachineEngineer> Machines { get; set; }
    public virtual ICollection<IncidentJoin> Incidents { get; set; }
  }
}