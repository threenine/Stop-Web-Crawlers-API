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

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);
               
            
            builder.Property(s => s.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.HasData(
                new ThreatType {Id = 1, Name = "Referrer Spam", Description = "a Referrer spammer"},
                new ThreatType {Id = 2, Name = "Web Crawler", Description = "potential search engine or index spider"}
               
            );
        }
    }
}