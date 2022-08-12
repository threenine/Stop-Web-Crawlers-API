using Threenine.Models;

namespace Threenine.Diogels
{
    public class Status : BaseEntity
    {
        public Status()
        {
        }

      
       public string Name { get; set; }
       
        public string  Description { get; set; }

        public virtual ICollection<Classification> Classifications { get; set; }
    }
}
