﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class AddCampusEntite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCampus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressCampus = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PhoneCampus = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_NameCampus",
                table: "Sedes",
                column: "NameCampus",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressCampus = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NameCampus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneCampus = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campuses_NameCampus",
                table: "Campuses",
                column: "NameCampus",
                unique: true);
        }
    }
}
