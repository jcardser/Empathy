using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_SedeAppointmets_Appointments_AppointmentId",
                table: "SedeAppointmets");

            migrationBuilder.DropForeignKey(
                name: "FK_SedeAppointmets_Categories_CategoryId",
                table: "SedeAppointmets");

            migrationBuilder.DropForeignKey(
                name: "FK_SedeAppointmets_Sedes_SedeId",
                table: "SedeAppointmets");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_Name_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name_StateId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SedeAppointmets",
                table: "SedeAppointmets");

            migrationBuilder.DropIndex(
                name: "IX_SedeAppointmets_AppointmentId_SedeId",
                table: "SedeAppointmets");

            migrationBuilder.DropIndex(
                name: "IX_SedeAppointmets_CategoryId",
                table: "SedeAppointmets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SedeAppointmets");

            migrationBuilder.RenameTable(
                name: "SedeAppointmets",
                newName: "SedesAppointmets");

            migrationBuilder.RenameIndex(
                name: "IX_SedeAppointmets_SedeId",
                table: "SedesAppointmets",
                newName: "IX_SedesAppointmets_SedeId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "States",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sedes",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MethodMenstrual",
                table: "HealthConditions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Menstrual",
                table: "HealthConditions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Medicine",
                table: "HealthConditions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Fracture",
                table: "HealthConditions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "SedesAppointmets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SedesAppointmets",
                table: "SedesAppointmets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProfessional = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalsSede",
                columns: table => new
                {
                    ProfessionalsId = table.Column<int>(type: "int", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalsSede", x => new { x.ProfessionalsId, x.SedeId });
                    table.ForeignKey(
                        name: "FK_ProfessionalsSede_Professional_ProfessionalsId",
                        column: x => x.ProfessionalsId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalsSede_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_Name_CountryId",
                table: "States",
                columns: new[] { "Name", "CountryId" },
                unique: true,
                filter: "[CountryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_CategoryId",
                table: "Sedes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_StateId",
                table: "Cities",
                columns: new[] { "Name", "StateId" },
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SedesAppointmets_AppointmentId",
                table: "SedesAppointmets",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Professional_Id",
                table: "Professional",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalsSede_SedeId",
                table: "ProfessionalsSede",
                column: "SedeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sedes_Categories_CategoryId",
                table: "Sedes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SedesAppointmets_Appointments_AppointmentId",
                table: "SedesAppointmets",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SedesAppointmets_Sedes_SedeId",
                table: "SedesAppointmets",
                column: "SedeId",
                principalTable: "Sedes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Sedes_Categories_CategoryId",
                table: "Sedes");

            migrationBuilder.DropForeignKey(
                name: "FK_SedesAppointmets_Appointments_AppointmentId",
                table: "SedesAppointmets");

            migrationBuilder.DropForeignKey(
                name: "FK_SedesAppointmets_Sedes_SedeId",
                table: "SedesAppointmets");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropTable(
                name: "ProfessionalsSede");

            migrationBuilder.DropTable(
                name: "Professional");

            migrationBuilder.DropIndex(
                name: "IX_States_Name_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Sedes_CategoryId",
                table: "Sedes");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Name_StateId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SedesAppointmets",
                table: "SedesAppointmets");

            migrationBuilder.DropIndex(
                name: "IX_SedesAppointmets_AppointmentId",
                table: "SedesAppointmets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sedes");

            migrationBuilder.RenameTable(
                name: "SedesAppointmets",
                newName: "SedeAppointmets");

            migrationBuilder.RenameIndex(
                name: "IX_SedesAppointmets_SedeId",
                table: "SedeAppointmets",
                newName: "IX_SedeAppointmets_SedeId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "States",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MethodMenstrual",
                table: "HealthConditions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Menstrual",
                table: "HealthConditions",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Medicine",
                table: "HealthConditions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fracture",
                table: "HealthConditions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "SedeAppointmets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SedeAppointmets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SedeAppointmets",
                table: "SedeAppointmets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_States_Name_CountryId",
                table: "States",
                columns: new[] { "Name", "CountryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name_StateId",
                table: "Cities",
                columns: new[] { "Name", "StateId" },
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Cities_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SedeAppointmets_Appointments_AppointmentId",
                table: "SedeAppointmets",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SedeAppointmets_Categories_CategoryId",
                table: "SedeAppointmets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SedeAppointmets_Sedes_SedeId",
                table: "SedeAppointmets",
                column: "SedeId",
                principalTable: "Sedes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
