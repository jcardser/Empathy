using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empathy.Migrations
{
    /// <inheritdoc />
    public partial class AddHealthConditionEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surgery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Height = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Smoke = table.Column<bool>(type: "bit", nullable: false),
                    Beer = table.Column<bool>(type: "bit", nullable: false),
                    Fracture = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthConditions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthConditions");
        }
    }
}
