using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Api.Database;

namespace Api.Database.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("Portal")
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Database.Entity.Threats.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Threat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Host");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Protocol");

                    b.Property<string>("QueryString");

                    b.Property<string>("Referer")
                        .HasMaxLength(255);

                    b.Property<int>("StatusId");

                    b.Property<int>("TypeId");

                    b.Property<string>("UserAgent");

                    b.Property<string>("XForwardHost");

                    b.Property<string>("XForwardProto");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("TypeId");

                    b.ToTable("Threats");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.ThreatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("Api.Database.Entity.Threats.Threat", b =>
                {
                    b.HasOne("Api.Database.Entity.Threats.Status", "Status")
                        .WithMany("Threats")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Api.Database.Entity.Threats.ThreatType", "Type")
                        .WithMany("Threats")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
