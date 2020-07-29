using System;

namespace Threenine.Diogel.Database.Entity.Threats
{
    public class Threat
    {
        public Guid Identifier { get; set; }

        public string Name { get; set; }

        public string Referer { get; set; }

        public string Host { get; set; }

        public string UserAgent { get; set; }

        public string XForwardHost { get; set; }

        public string XForwardProto { get; set; }

        public string QueryString { get; set; }

        public string Protocol { get; set; }

      
    }
}