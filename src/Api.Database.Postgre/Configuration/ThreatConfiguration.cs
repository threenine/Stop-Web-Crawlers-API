using Api.Database.Entity.Threats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Postgre.Configuration
{
    public class ThreatConfiguration  : IEntityTypeConfiguration<Threat>
    {
        private const string TableName = "threat";
        public void Configure(EntityTypeBuilder<Threat> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(x => x.Identifier);

            builder.Property(x => x.Identifier)
                .HasColumnName("identifier")
                .HasColumnType("varchar(36)")
                .HasMaxLength(36)
                .IsRequired();

            builder.HasIndex(x => x.Identifier)
                .HasName("identifier")
                .IsUnique();

            builder.Property(x => x.Host)
                .HasColumnName("host")
                .HasColumnType("varchar(41)")
                .HasMaxLength(41);

            builder.Property(x => x.Referer)
                .HasColumnName("referrer")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(x => x.QueryString)
                .HasColumnName("query_string")
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(x => x.XForwardHost)
                .HasColumnName("x_forward_host")
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(x => x.XForwardProto)
                .HasColumnName("x_forward_proto")
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.Property(kt => kt.Protocol)
                .HasColumnType("varchar(20)")
                .HasMaxLength(256)
                .HasColumnType("varchar(256)");

            builder.HasOne(x => x.Status)
                .WithMany(t => t.Threats)
                .HasForeignKey(dt => dt.StatusId);

            builder.HasOne(d => d.ThreatType)
                .WithMany(t => t.Threats)
                .HasForeignKey(dt => dt.TypeId);
        }
    }
}