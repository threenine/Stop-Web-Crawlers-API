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
            builder.ToTable(TableName);

            builder.HasKey(kt => kt.Id);

            builder.Property(kt => kt.Name)
                .HasColumnType("varchar(45)")
                .HasConversion<string>();

            builder.HasData(
                new ThreatType {Id = 1, Name = "Active"},
                new ThreatType {Id = 2, Name = "Malignent"}
               
            );
        }
    }
}