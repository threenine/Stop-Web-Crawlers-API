using Api.Database.Entity.Threats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Postgre.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        private const string TableName = "status";
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}