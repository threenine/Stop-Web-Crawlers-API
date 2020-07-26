using Api.Database.Entity.Threats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Postgre.Configuration
{
    public class ThreatTypeConfiguration : IEntityTypeConfiguration<ThreatType>
    {
        private const string TableName = "threat_type";
        public void Configure(EntityTypeBuilder<ThreatType> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(kt => kt.Id);

            builder.Property(kt => kt.Name)
                .HasColumnType("varchar(45)")
                .HasConversion<string>();

            builder.HasData(
                new ThreatType {Id = 1, Name = "Referrer Spam"},
                new ThreatType {Id = 2, Name = "Web Crawler"}
               
            );
        }
    }
}