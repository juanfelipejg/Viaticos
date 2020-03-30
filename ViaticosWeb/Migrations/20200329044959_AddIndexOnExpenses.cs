using Microsoft.EntityFrameworkCore.Migrations;

namespace ViaticosWeb.Migrations
{
    public partial class AddIndexOnExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeExpense",
                table: "Expenses",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeExpense",
                table: "Expenses",
                column: "TypeExpense",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expenses_TypeExpense",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "TypeExpense",
                table: "Expenses",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
