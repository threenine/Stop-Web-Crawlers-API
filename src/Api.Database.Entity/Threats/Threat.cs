using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Entity.Threats
{
    public class Threat : BaseEntity
    {
      
        public string Identifier { get; set; }

        public string Referer { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string XForwardHost { get; set; }

        public string XForwardProto { get; set; }

        public string QueryString { get; set; }

        public string Protocol { get; set; }

        public int TypeId { get; set; }
        public int StatusId { get; set; }

        [ForeignKey("TypeId")] public virtual ThreatType ThreatType { get; set; }

        [ForeignKey("StatusId")] public virtual Status Status { get; set; }
    }
}