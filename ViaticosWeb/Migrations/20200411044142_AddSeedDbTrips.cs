using Microsoft.EntityFrameworkCore.Migrations;

namespace ViaticosWeb.Migrations
{
    public partial class AddSeedDbTrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Trips",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Trips");
        }
    }
}
