using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket_booking_API.Migrations
{
    public partial class notmappedEmailToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmedToken",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmedToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
