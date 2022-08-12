using Threenine.Models;

namespace Threenine.Diogels
{
    public class Type : BaseEntity
    {
        public Type()
        {
        }

        
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual ICollection<Classification> Classifications { get; set; }
    }
}