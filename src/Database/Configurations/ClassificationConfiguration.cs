using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;
using Threenine.Diogels;

namespace Threenine.Configurations
{
    public class ClassificationConfiguration : BaseEntityTypeConfiguration<Classification>
    {
        public override void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.ToTable(nameof(Classification).ToLower());
            builder.HasKey(s => new  { s.ThreatId, s.StatusId, s.TypeId} );

            builder.Property(x => x.ThreatId)
                .HasColumnType(ColumnTypes.UniqueIdentifier)
                .IsRequired();
                
            builder.Property(x => x.StatusId)
                .HasColumnType(ColumnTypes.UniqueIdentifier)
              
                .IsRequired();

            builder.Property(x => x.TypeId)
                .HasColumnType(ColumnTypes.UniqueIdentifier)
             
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