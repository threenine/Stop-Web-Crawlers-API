using System;
using System.ComponentModel.DataAnnotations;

using Threenine.Diogel.Database.Entity.Threats;


namespace Threenine.Diogel.Domain.Bots
{
  public class AddRefererer
    {
        [Required, StringLength(55)]
        public string Referer { get; set; }
        
        [Required, StringLength(256)]
        public Uri Url { get; set; }

      
    }
}
