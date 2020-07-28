using Api.Database.Entity.Threats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Postgre.Configuration
{
    internal class ThreatTypeConfiguration : IEntityTypeConfiguration<ThreatType>
    {
       
        public void Configure(EntityTypeBuilder<ThreatType> builder)
        {
            builder.ToTable(TableName.ThreatType);

            builder.HasKey(t => t.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn()
                .HasColumnType(ColumnTypeName.INT);
            

            builder.Property(t => t.Name)
                .HasColumnName("name")
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(45);
               
            
            builder.Property(s => s.Description)
                .HasColumnName("description")
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(255);

            builder.HasData(
                new ThreatType {Id = 1, Name = "Referrer Spam", Description = "a Referrer spammer"},
                new ThreatType {Id = 2, Name = "Web Crawler", Description = "potential search engine or index spider"}
               
            );
        }
    }
}