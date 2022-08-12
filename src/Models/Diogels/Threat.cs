using Threenine.Models;

namespace Threenine.Diogels
{
    public class Threat : BaseEntity
    {
        

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