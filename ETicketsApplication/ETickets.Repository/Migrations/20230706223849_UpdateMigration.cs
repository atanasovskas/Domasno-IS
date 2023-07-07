using Microsoft.EntityFrameworkCore.Migrations;

namespace ETickets.Repository.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcertImage",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieImage",
                table: "Tickets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MovieImage",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "ConcertImage",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
