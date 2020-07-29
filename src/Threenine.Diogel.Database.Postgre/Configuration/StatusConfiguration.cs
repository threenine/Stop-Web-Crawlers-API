using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Diogel.Database.Entity.Threats;
using Threenine.Diogel.Database.Postgre.Constants;

namespace Threenine.Diogel.Database.Postgre.Configuration
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
      
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(TableName.Status);

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasColumnName(ColumnName.Name)
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(45);

            builder.Property(s => s.Description)
                .HasColumnName(ColumnName.Description)
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(255);

            builder.HasData(
                new Status {Id = 1, Name = "Active", Description = "A current active threat"},
                new Status {Id = 2, Name = "Malign", Description = "Highly dangerous threat"},
                new Status {Id = 3, Name = "Benign", Description = "Active threat but not known to harmful"}
               
            );
        }
    }
}