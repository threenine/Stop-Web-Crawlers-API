using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Database.Postgre.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "threat_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 45, nullable: true),
                    description = table.Column<string>(type: "varchar", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threat_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "threat",
                columns: table => new
                {
                    identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 55, nullable: false),
                    referrer = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    host = table.Column<string>(type: "varchar", maxLength: 41, nullable: true),
                    user_agent = table.Column<string>(type: "varchar", maxLength: 35, nullable: true),
                    x_forward_host = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    x_forward_proto = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    query_string = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    protocol = table.Column<string>(type: "varchar", maxLength: 256, nullable: true),
                    threat_type_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_threat", x => x.identifier);
                    table.ForeignKey(
                        name: "FK_threat_status_status_id",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_threat_threat_type_threat_type_id",
                        column: x => x.threat_type_id,
                        principalTable: "threat_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "A current active threat", "Active" },
                    { 2, "Highly dangerous threat", "Malign" },
                    { 3, "Active threat but not known to harmful", "Benign" }
                });

            migrationBuilder.InsertData(
                table: "threat_type",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "a Referrer spammer", "Referrer Spam" },
                    { 2, "potential search engine or index spider", "Web Crawler" }
                });

            migrationBuilder.CreateIndex(
                name: "identifier",
                table: "threat",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_threat_status_id",
                table: "threat",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_threat_threat_type_id",
                table: "threat",
                column: "threat_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "threat");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "threat_type");
        }
    }
}
