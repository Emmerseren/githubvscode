using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HåndværkerCase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: false),
                    Adresse = table.Column<string>(type: "TEXT", nullable: false),
                    Beskrivelse = table.Column<string>(type: "TEXT", nullable: false),
                    StartsDato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SlutsDato = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "beskrivelser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    beskrivelse = table.Column<string>(type: "TEXT", nullable: true),
                    Pris = table.Column<decimal>(type: "TEXT", nullable: false),
                    CaseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_beskrivelser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_beskrivelser_cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beskrivelser_CaseId",
                table: "beskrivelser",
                column: "CaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beskrivelser");

            migrationBuilder.DropTable(
                name: "cases");
        }
    }
}
