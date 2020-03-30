using Microsoft.EntityFrameworkCore.Migrations;

namespace ViaticosWeb.Migrations
{
    public partial class AddEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "Trips");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Trips",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TripDetailEntityId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TripDetailEntityId",
                table: "Expenses",
                column: "TripDetailEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_TripDetails_TripDetailEntityId",
                table: "Expenses",
                column: "TripDetailEntityId",
                principalTable: "TripDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_TripDetails_TripDetailEntityId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_TripDetailEntityId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TripDetailEntityId",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "Trips",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
