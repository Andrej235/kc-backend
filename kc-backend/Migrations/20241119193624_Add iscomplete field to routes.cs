using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kc_backend.Migrations
{
    /// <inheritdoc />
    public partial class Addiscompletefieldtoroutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Routes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Routes");
        }
    }
}
