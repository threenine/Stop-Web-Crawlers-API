using System;

namespace Threenine.Diogel.Database.Entity.Threats
{
    public class Classification
    {
        public Guid ThreatId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }

        public virtual Threat Threat { get; set; }
        public virtual Type Type { get; set; }
        public virtual Status Status { get; set; }


    }
}