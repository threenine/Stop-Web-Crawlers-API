using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Database.Entity.Threats
{
    public class ThreatType 
    {
        public ThreatType()
        {
          
        }
       public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<Threat> Threats { get; set; }
    }
}
