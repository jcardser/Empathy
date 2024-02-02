using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class AddSedeAppointmentEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Beer",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CardiacHistory",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ConditionHistory",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Fracture",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PressureHistory",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Smoke",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SugarHistory",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "BloodPressure",
                table: "Histories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BreathingFrequency",
                table: "Histories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeartRate",
                table: "Histories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Histories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Histories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HealthConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConditionHistory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Medicine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Surgery = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CardiacHistory = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Height = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fracture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sport = table.Column<bool>(type: "bit", nullable: false),
                    Menstrual = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MethodMenstrual = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Smoke = table.Column<bool>(type: "bit", nullable: false),
                    Beer = table.Column<bool>(type: "bit", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SedeAppointmets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SedeAppointmets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SedeAppointmets_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SedeAppointmets_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SedeAppointmets_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SedeAppointmets_AppointmentId_SedeId",
                table: "SedeAppointmets",
                columns: new[] { "AppointmentId", "SedeId" },
                unique: true,
                filter: "[SedeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SedeAppointmets_CategoryId",
                table: "SedeAppointmets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SedeAppointmets_SedeId",
                table: "SedeAppointmets",
                column: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthConditions");

            migrationBuilder.DropTable(
                name: "SedeAppointmets");

            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "BreathingFrequency",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "HeartRate",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Histories");

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

            migrationBuilder.AddColumn<bool>(
                name: "Beer",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CardiacHistory",
                table: "Appointments",
                type: "bit",
                maxLength: 300,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ConditionHistory",
                table: "Appointments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Fracture",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "Appointments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PressureHistory",
                table: "Appointments",
                type: "bit",
                maxLength: 300,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Smoke",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SugarHistory",
                table: "Appointments",
                type: "bit",
                maxLength: 300,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "Appointments",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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
    }
}
