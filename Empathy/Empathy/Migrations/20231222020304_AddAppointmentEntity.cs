using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthConditions");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Sedes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sedes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Procedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ConditionHistory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CardiacHistory = table.Column<bool>(type: "bit", maxLength: 300, nullable: false),
                    PressureHistory = table.Column<bool>(type: "bit", maxLength: 300, nullable: false),
                    SugarHistory = table.Column<bool>(type: "bit", maxLength: 300, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Height = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Smoke = table.Column<bool>(type: "bit", nullable: false),
                    Beer = table.Column<bool>(type: "bit", nullable: false),
                    Fracture = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhysicalExam = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_AppointmentId",
                table: "Sedes",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_CategoryId",
                table: "Sedes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_HistoryId",
                table: "Procedures",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AppointmentId",
                table: "Categories",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Id",
                table: "Appointments",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Appointments_AppointmentId",
                table: "Categories",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Histories_HistoryId",
                table: "Procedures",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sedes_Appointments_AppointmentId",
                table: "Sedes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sedes_Categories_CategoryId",
                table: "Sedes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Appointments_AppointmentId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Histories_HistoryId",
                table: "Procedures");

            migrationBuilder.DropForeignKey(
                name: "FK_Sedes_Appointments_AppointmentId",
                table: "Sedes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sedes_Categories_CategoryId",
                table: "Sedes");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Sedes_AppointmentId",
                table: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_Sedes_CategoryId",
                table: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_HistoryId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AppointmentId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "HealthConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergies = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beer = table.Column<bool>(type: "bit", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fracture = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Smoke = table.Column<bool>(type: "bit", nullable: false),
                    Surgery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditions", x => x.Id);
                });
        }
    }
}
