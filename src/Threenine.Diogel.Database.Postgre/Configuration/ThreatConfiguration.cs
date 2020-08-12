using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine.Diogel.Database.Entity.Threats;
using Threenine.Diogel.Database.Postgre.Constants;

namespace Threenine.Diogel.Database.Postgre.Configuration
{
    internal class ThreatConfiguration : IEntityTypeConfiguration<Threat>
    {
        public void Configure(EntityTypeBuilder<Threat> builder)
        {
            builder.ToTable(TableName.Threat);
            builder.HasKey(x => x.Identifier);
            
            builder.HasIndex(x => x.Identifier)
                .HasName(ColumnName.Identifier)
                .IsUnique();

            builder.Property(x => x.Identifier)
                .HasColumnName(ColumnName.Identifier)
                .HasColumnType(ColumnTypeName.UUID)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName(ColumnName.Name)
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(55)
                .IsRequired();

            builder.Property(x => x.Host)
                .HasColumnName(ColumnName.Host)
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(41);

            builder.Property(x => x.Referer)
                .HasColumnName(ColumnName.Referrer)
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(256);

            builder.Property(x => x.QueryString)
                .HasColumnName(ColumnName.QueryString)
                .HasMaxLength(256)
                .HasColumnType(ColumnTypeName.VARCHAR);

            builder.Property(x => x.XForwardHost)
                .HasColumnName(ColumnName.XForwardHost)
                .HasMaxLength(256)
                .HasColumnType(ColumnTypeName.VARCHAR);

            builder.Property(x => x.XForwardProto)
                .HasColumnName(ColumnName.xForwardProto)
                .HasMaxLength(256)
                .HasColumnType(ColumnTypeName.VARCHAR);

            builder.Property(kt => kt.Protocol)
                .HasColumnName(ColumnName.Protocol)
                .HasMaxLength(256)
                .HasColumnType(ColumnTypeName.VARCHAR);

            builder.Property(x => x.UserAgent)
                .HasColumnName(ColumnName.UserAgent)
                .HasColumnType(ColumnTypeName.VARCHAR)
                .HasMaxLength(35);

          
        }
    }
}