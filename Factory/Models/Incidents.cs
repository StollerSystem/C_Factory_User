using System.Collections.Generic;

namespace Factory.Models
{
  public class Incident
  {
    public Incident()
    {      
      this.Engineers = new HashSet<Engineer>();
      this.Machines = new HashSet<Machine>();
          
    }
    public int IncidentId { get; set; }    
    public string Description { get; set; } 
    public string IncidentDate { get; set; } 
    public virtual ICollection<Engineer> Engineers { get; set; }
    public virtual ICollection<Machine> Machines { get; set; }
  }
}