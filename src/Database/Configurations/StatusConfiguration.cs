using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;
using Threenine.Diogels;

namespace Threenine.Configurations
{
    internal class StatusConfiguration : BaseEntityTypeConfiguration<Status>
    {
      
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(nameof(Status).ToLower());

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
               
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(45);

            builder.Property(s => s.Description)
              
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(255);
            
        }
    }
}