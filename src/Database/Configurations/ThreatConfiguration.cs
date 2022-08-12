using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Configurations.PostgreSql;
using Threenine.Diogels;

namespace Threenine.Configurations
{
    internal class ThreatConfiguration : BaseEntityTypeConfiguration<Threat>
    {
        public override void Configure(EntityTypeBuilder<Threat> builder)
        {
            builder.ToTable(nameof(Threat).ToLower());
          

           
            builder.Property(x => x.Name)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(55)
                .IsRequired();

            builder.Property(x => x.Host)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(41);

            builder.Property(x => x.Referer)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(256);

            builder.Property(x => x.QueryString)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(256);


            builder.Property(x => x.XForwardHost)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(256);


            builder.Property(x => x.XForwardProto)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(256);


            builder.Property(kt => kt.Protocol)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(256);
               

            builder.Property(x => x.UserAgent)
                .HasColumnType(ColumnTypes.Varchar)
                .HasMaxLength(35);

          
        }
    }
}