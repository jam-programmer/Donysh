using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MailSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MailHost",
                schema: "Dy",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MailHostPort",
                schema: "Dy",
                table: "Setting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailReceiver",
                schema: "Dy",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailSender",
                schema: "Dy",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpPassword",
                schema: "Dy",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmtpUserName",
                schema: "Dy",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailHost",
                schema: "Dy",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "MailHostPort",
                schema: "Dy",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "MailReceiver",
                schema: "Dy",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "MailSender",
                schema: "Dy",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SmtpPassword",
                schema: "Dy",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SmtpUserName",
                schema: "Dy",
                table: "Setting");
        }
    }
}
