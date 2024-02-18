using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SedeProfessionals_Professionals_ProfessionalId",
                table: "SedeProfessionals");

            migrationBuilder.DropForeignKey(
                name: "FK_SedeProfessionals_Sedes_SedeId",
                table: "SedeProfessionals");

            migrationBuilder.AlterColumn<int>(
                name: "SedeId",
                table: "SedeProfessionals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionalId",
                table: "SedeProfessionals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentProfessionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentProfessionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentProfessionals_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentProfessionals_Professionals_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentProfessionals_AppointmentId",
                table: "AppointmentProfessionals",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentProfessionals_ProfessionalId",
                table: "AppointmentProfessionals",
                column: "ProfessionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_SedeProfessionals_Professionals_ProfessionalId",
                table: "SedeProfessionals",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SedeProfessionals_Sedes_SedeId",
                table: "SedeProfessionals",
                column: "SedeId",
                principalTable: "Sedes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SedeProfessionals_Professionals_ProfessionalId",
                table: "SedeProfessionals");

            migrationBuilder.DropForeignKey(
                name: "FK_SedeProfessionals_Sedes_SedeId",
                table: "SedeProfessionals");

            migrationBuilder.DropTable(
                name: "AppointmentProfessionals");

            migrationBuilder.AlterColumn<int>(
                name: "SedeId",
                table: "SedeProfessionals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionalId",
                table: "SedeProfessionals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SedeProfessionals_Professionals_ProfessionalId",
                table: "SedeProfessionals",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SedeProfessionals_Sedes_SedeId",
                table: "SedeProfessionals",
                column: "SedeId",
                principalTable: "Sedes",
                principalColumn: "Id");
        }
    }
}
