using System.Collections.Generic;

namespace Factory.Models
{
  public class Incident
  {
    public Incident()
    {      
      this.IncidentJoin = new HashSet<IncidentJoin>();
      
          
    }
    public int IncidentId { get; set; }    

    public string IncidentTitle { get; set; }
    public string Description { get; set; } 
    public string IncidentDate { get; set; } 
    public virtual ICollection<IncidentJoin> IncidentJoin { get; set; }
    
  }
}