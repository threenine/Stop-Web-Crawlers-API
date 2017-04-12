using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portal.Database.Entity.Threats
{
  public class Status : BaseEntity
    {
        public Status()
        {
            Threats = new List<Threat>();
        }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(255)]
        public string  Description { get; set; }


        public virtual ICollection<Threat> Threats { get; set; }
    }
}
