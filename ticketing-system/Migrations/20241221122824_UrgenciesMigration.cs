using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketing_system.Migrations
{
    /// <inheritdoc />
    public partial class UrgenciesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "urgencies",
                columns: table => new
                {
                    urgency_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_urgencies", x => x.urgency_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urgencies");
        }
    }
}
