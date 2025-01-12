using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ticketing_system.Migrations
{
    /// <inheritdoc />
    public partial class UserTypesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_types",
                columns: table => new
                {
                    user_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_types", x => x.user_type_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_types");
        }
    }
}
