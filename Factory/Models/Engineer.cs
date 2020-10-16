using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {      
    //   this.Engineers = new HashSet<EngineerEngineer>();
          
    }
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }    
    // public virtual ICollection<MachineEngineer> Engineers { get; set; }
  }
}