using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentUnionUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Procedures_TypeProcedure",
                table: "Procedures");

            migrationBuilder.CreateTable(
                name: "AppointmentUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentUsers_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryProcedure",
                columns: table => new
                {
                    HistoriesId = table.Column<int>(type: "int", nullable: false),
                    ProceduresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryProcedure", x => new { x.HistoriesId, x.ProceduresId });
                    table.ForeignKey(
                        name: "FK_HistoryProcedure_Histories_HistoriesId",
                        column: x => x.HistoriesId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryProcedure_Procedures_ProceduresId",
                        column: x => x.ProceduresId,
                        principalTable: "Procedures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentUsers_AppointmentId",
                table: "AppointmentUsers",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentUsers_UserId",
                table: "AppointmentUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryProcedure_ProceduresId",
                table: "HistoryProcedure",
                column: "ProceduresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentUsers");

            migrationBuilder.DropTable(
                name: "HistoryProcedure");

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_TypeProcedure",
                table: "Procedures",
                column: "TypeProcedure",
                unique: true);
        }
    }
}
