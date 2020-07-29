using System.Collections.Generic;

namespace Threenine.Diogel.Database.Entity.Threats
{
    public class Status
    {
        public Status()
        {
        }

        public int Id { get; set; }
       public string Name { get; set; }
       
        public string  Description { get; set; }

        public virtual ICollection<Classification> Classifications { get; set; }
    }
}
