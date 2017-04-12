using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Database.Entity.Threats
{
    public class ThreatType : BaseEntity
    {

        public ThreatType()
        {
            Threats = new List<Threat>();
        }

        [Required]
        [StringLength(50)]
        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<Threat> Threats { get; set; }
    }
}
