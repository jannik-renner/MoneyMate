using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyMate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConnectAccountGroupsToHouseholdAccountBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanBeDeleted",
                table: "account_group",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseholdAccountBookId",
                table: "account_group",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CanBeDeleted",
                table: "account",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "account_group",
                columns: new[] { "Name", "Description", "HouseholdAccountBookId", "Type", "CanBeDeleted" },
                values: new object[,]
                {
                    { "Sonstige Ausgaben", "Sonstige monatliche Ausgaben", null, "EXP", false },
                    { "Sonstige Einnahmen", "Sonstige monatliche Einnahmen", null, "INC", false }
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Name", "AccountGroupName", "CanBeDeleted" },
                values: new object[,]
                {
                    { "Sonstige Ausgaben", "Sonstige Ausgaben", false },
                    { "Sonstige Einnahmen", "Sonstige Einnahmen", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_group_HouseholdAccountBookId",
                table: "account_group",
                column: "HouseholdAccountBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_group_household_account_book_HouseholdAccountBookId",
                table: "account_group",
                column: "HouseholdAccountBookId",
                principalTable: "household_account_book",
                principalColumn: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_group_household_account_book_HouseholdAccountBookId",
                table: "account_group");

            migrationBuilder.DropIndex(
                name: "IX_account_group_HouseholdAccountBookId",
                table: "account_group");

            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "Name",
                keyValue: "Sonstige Ausgaben");

            migrationBuilder.DeleteData(
                table: "account",
                keyColumn: "Name",
                keyValue: "Sonstige Einnahmen");

            migrationBuilder.DeleteData(
                table: "account_group",
                keyColumn: "Name",
                keyValue: "Sonstige Ausgaben");

            migrationBuilder.DeleteData(
                table: "account_group",
                keyColumn: "Name",
                keyValue: "Sonstige Einnahmen");

            migrationBuilder.DropColumn(
                name: "CanBeDeleted",
                table: "account_group");

            migrationBuilder.DropColumn(
                name: "HouseholdAccountBookId",
                table: "account_group");

            migrationBuilder.DropColumn(
                name: "CanBeDeleted",
                table: "account");
        }
    }
}
