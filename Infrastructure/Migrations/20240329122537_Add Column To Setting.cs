using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryBanner",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactBanner",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectBanner",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestBanner",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkWithBanner",
                schema: "dbo",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryBanner",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ContactBanner",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ProjectBanner",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "RequestBanner",
                schema: "dbo",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "WorkWithBanner",
                schema: "dbo",
                table: "Setting");
        }
    }
}
