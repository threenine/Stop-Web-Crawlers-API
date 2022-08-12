using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Threenine.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Diogel");

            migrationBuilder.CreateTable(
                name: "status",
                schema: "Diogel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 45, nullable: true),
                    Description = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "threat",
                schema: "Diogel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 55, nullable: false),
                    Referer = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    Host = table.Column<string>(type: "varchar", maxLength: 41, nullable: true),
                    UserAgent = table.Column<string>(type: "varchar", maxLength: 35, nullable: true),
                    XForwardHost = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    XForwardProto = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    QueryString = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    Protocol = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "type",
                schema: "Diogel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 45, nullable: true),
                    Description = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "classification",
                schema: "Diogel",
                columns: table => new
                {
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThreatId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classification", x => new { x.ThreatId, x.StatusId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_classification_status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Diogel",
                        principalTable: "status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classification_threat_ThreatId",
                        column: x => x.ThreatId,
                        principalSchema: "Diogel",
                        principalTable: "threat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classification_type_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Diogel",
                        principalTable: "type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classification_StatusId",
                schema: "Diogel",
                table: "classification",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_classification_TypeId",
                schema: "Diogel",
                table: "classification",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classification",
                schema: "Diogel");

            migrationBuilder.DropTable(
                name: "status",
                schema: "Diogel");

            migrationBuilder.DropTable(
                name: "threat",
                schema: "Diogel");

            migrationBuilder.DropTable(
                name: "type",
                schema: "Diogel");
        }
    }
}
