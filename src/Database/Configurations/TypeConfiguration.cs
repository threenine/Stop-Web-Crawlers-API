using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;

namespace Threenine.Configurations
{
    internal class TypeConfiguration : BaseEntityTypeConfiguration<Diogels.Type>
    {
       
        public override void Configure(EntityTypeBuilder<Diogels.Type> builder)
        {
            builder.ToTable(nameof(Type).ToLower());

            builder.Property(t => t.Name)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(45);
               
            
            builder.Property(s => s.Description)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(255);
          
        }
    }
}