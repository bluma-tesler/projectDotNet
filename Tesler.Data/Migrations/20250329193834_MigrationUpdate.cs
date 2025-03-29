using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tesler.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registered",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Registered",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
