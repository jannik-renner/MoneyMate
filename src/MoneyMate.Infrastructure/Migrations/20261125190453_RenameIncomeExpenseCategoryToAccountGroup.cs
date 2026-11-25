using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameIncomeExpenseCategoryToAccountGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_income_expense_income_expense_category_position_CategoryPositionId",
                table: "income_expense");

            migrationBuilder.DropTable(
                name: "income_expense_category_position");

            migrationBuilder.DropTable(
                name: "income_expense_category");

            migrationBuilder.RenameColumn(
                name: "CategoryPositionId",
                table: "income_expense",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_income_expense_CategoryPositionId",
                table: "income_expense",
                newName: "IX_income_expense_AccountId");

            migrationBuilder.CreateTable(
                name: "account_group",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "char(3)", nullable: false),
                    IsFixed = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_group", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    AccountGroupName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Name);
                    table.ForeignKey(
                        name: "FK_account_account_group_AccountGroupName",
                        column: x => x.AccountGroupName,
                        principalTable: "account_group",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_AccountGroupName",
                table: "account",
                column: "AccountGroupName");

            migrationBuilder.AddForeignKey(
                name: "FK_income_expense_account_AccountId",
                table: "income_expense",
                column: "AccountId",
                principalTable: "account",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_income_expense_account_AccountId",
                table: "income_expense");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "account_group");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "income_expense",
                newName: "CategoryPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_income_expense_AccountId",
                table: "income_expense",
                newName: "IX_income_expense_CategoryPositionId");

            migrationBuilder.CreateTable(
                name: "income_expense_category",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    IsFixed = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    Type = table.Column<string>(type: "char(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_expense_category", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "income_expense_category_position",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_expense_category_position", x => x.Name);
                    table.ForeignKey(
                        name: "FK_income_expense_category_position_income_expense_category_CategoryName",
                        column: x => x.CategoryName,
                        principalTable: "income_expense_category",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_income_expense_category_position_CategoryName",
                table: "income_expense_category_position",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_income_expense_income_expense_category_position_CategoryPositionId",
                table: "income_expense",
                column: "CategoryPositionId",
                principalTable: "income_expense_category_position",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
