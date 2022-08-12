using Threenine.Models;

namespace Threenine.Diogels
{
    public class Classification : BaseEntity

    {
   
    public Guid TypeId { get; set; }
    public Guid StatusId { get; set; }

    public Guid ThreatId { get; set; }
    public virtual Threat Threat { get; set; }
    public virtual Type Type { get; set; }
    public virtual Status Status { get; set; }


    }
}