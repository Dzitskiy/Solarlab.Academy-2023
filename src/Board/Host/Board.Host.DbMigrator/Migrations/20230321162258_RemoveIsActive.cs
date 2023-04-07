using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Host.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Category",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
