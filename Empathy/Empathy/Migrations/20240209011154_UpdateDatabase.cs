using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SedeProfessionals_SedeId_ProfessionalId",
                table: "SedeProfessionals");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sedes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Sedes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhtoneCampus",
                table: "Sedes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionalId",
                table: "Sedes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_AppointmentId",
                table: "Sedes",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_ProfessionalId",
                table: "Sedes",
                column: "ProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SedeProfessionals_SedeId",
                table: "SedeProfessionals",
                column: "SedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sedes_Appointments_AppointmentId",
                table: "Sedes",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sedes_Professionals_ProfessionalId",
                table: "Sedes",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sedes_Appointments_AppointmentId",
                table: "Sedes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sedes_Professionals_ProfessionalId",
                table: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_Sedes_AppointmentId",
                table: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_Sedes_ProfessionalId",
                table: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_SedeProfessionals_SedeId",
                table: "SedeProfessionals");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "PhtoneCampus",
                table: "Sedes");

            migrationBuilder.DropColumn(
                name: "ProfessionalId",
                table: "Sedes");

            migrationBuilder.CreateIndex(
                name: "IX_SedeProfessionals_SedeId_ProfessionalId",
                table: "SedeProfessionals",
                columns: new[] { "SedeId", "ProfessionalId" },
                unique: true,
                filter: "[SedeId] IS NOT NULL AND [ProfessionalId] IS NOT NULL");
        }
    }
}
