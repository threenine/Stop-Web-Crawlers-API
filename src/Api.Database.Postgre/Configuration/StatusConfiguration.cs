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

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(45)")
                .HasMaxLength(45);

            builder.Property(s => s.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
                
                

            builder.HasData(
                new Status {Id = 1, Name = "Active", Description = "A current active threat"},
                new Status {Id = 2, Name = "Malign", Description = "Highly dangerous threat"},
                new Status {Id = 3, Name = "Benign", Description = "Active threat but not known to harmful"}
               
            );
        }
    }
}