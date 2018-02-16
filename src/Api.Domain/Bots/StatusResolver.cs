using Api.Database.Entity.Threats;
using AutoMapper;

namespace Api.Domain.Bots
{

    public class StatusResolver : IValueResolver<Threat, Referrer, string>
    {
        public string Resolve(Threat source, Referrer destination, string destMember, ResolutionContext context)
        {
            return source.Status.Name;
        }
    }
}