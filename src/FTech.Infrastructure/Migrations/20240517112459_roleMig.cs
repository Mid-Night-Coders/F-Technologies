using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class roleMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Drivers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Drivers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
