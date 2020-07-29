using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Diogel.Database.Entity.Threats;
using Threenine.Diogel.Database.Postgre.Constants;

namespace Threenine.Diogel.Database.Postgre.Configuration
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.ToTable(TableName.Classification);
            builder.HasKey(s => new  { s.ThreatId, s.StatusId, s.TypeId} );

            builder.Property(x => x.ThreatId)
                .HasColumnName(ColumnName.Identifier)
                .HasColumnType(ColumnTypeName.UUID)
                .IsRequired();
                
            builder.Property(x => x.StatusId)
                .HasColumnType(ColumnTypeName.INT)
                .HasColumnName(ColumnName.StatusId)
                .IsRequired();

            builder.Property(x => x.TypeId)
                .HasColumnType(ColumnTypeName.INT)
                .HasColumnName(ColumnName.TypeId)
                .IsRequired();

            builder.HasOne(x => x.Status)
                .WithMany(t => t.Classifications)
                .HasForeignKey(dt => dt.StatusId)
                ;

            builder.HasOne(d => d.Type)
                .WithMany(t => t.Classifications)
                .HasForeignKey(dt => dt.TypeId);
        }
    }
}