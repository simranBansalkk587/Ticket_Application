using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_booking_API.Migrations
{
    public partial class Addusertablecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmedToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfrimed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmedToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfrimed",
                table: "Users");
        }
    }
}
