using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchitect",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBuilder",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompletionDate",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsContractAmount",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDescription",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocation",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwnerOrDeveloper",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsProjectName",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReferenceContactAddress",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReferenceContactEmail",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReferenceContactName",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReferenceContactPhone",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsScopeForeignKey",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStartDate",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStatusForeignKey",
                schema: "Dy",
                table: "Project",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchitect",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsBuilder",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsCompletionDate",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsContractAmount",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsDescription",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsLocation",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsOwnerOrDeveloper",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsProjectName",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsReferenceContactAddress",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsReferenceContactEmail",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsReferenceContactName",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsReferenceContactPhone",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsScopeForeignKey",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsStartDate",
                schema: "Dy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsStatusForeignKey",
                schema: "Dy",
                table: "Project");
        }
    }
}
