
using Threenine.Diogel.Database.Entity.Threats;


namespace Threenine.Diogel.Domain.Bots
{
    public class Referrer 
    {
        public string Identifier { get; set; }
        public string Referer { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string XForwardHost { get; set; }

        public string XForwardProto { get; set; }

        public string QueryString { get; set; }

        public string Protocol { get; set; }


     
    }
}