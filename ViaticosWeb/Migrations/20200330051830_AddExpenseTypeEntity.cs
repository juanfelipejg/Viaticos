using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViaticosWeb.Migrations
{
    public partial class AddExpenseTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetails_Cities_CityId",
                table: "TripDetails");

            migrationBuilder.DropIndex(
                name: "IX_TripDetails_CityId",
                table: "TripDetails");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_TypeExpense",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TypeExpense",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "TypeExpenseId",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripDetailEntityId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpensesType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeExpense = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeExpenseId",
                table: "Expenses",
                column: "TypeExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TripDetailEntityId",
                table: "Cities",
                column: "TripDetailEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpensesType_TypeExpense",
                table: "ExpensesType",
                column: "TypeExpense",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_TripDetails_TripDetailEntityId",
                table: "Cities",
                column: "TripDetailEntityId",
                principalTable: "TripDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpensesType_TypeExpenseId",
                table: "Expenses",
                column: "TypeExpenseId",
                principalTable: "ExpensesType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_TripDetails_TripDetailEntityId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpensesType_TypeExpenseId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "ExpensesType");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_TypeExpenseId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_TripDetailEntityId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "TypeExpenseId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "TripDetailEntityId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "TripDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeExpense",
                table: "Expenses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_CityId",
                table: "TripDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TypeExpense",
                table: "Expenses",
                column: "TypeExpense",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetails_Cities_CityId",
                table: "TripDetails",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
