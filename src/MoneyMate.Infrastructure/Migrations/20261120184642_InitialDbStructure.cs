using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyMate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "household_account_book",
                columns: table => new
                {
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedTimestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChangedTimestamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_household_account_book", x => x.Year);
                });

            migrationBuilder.CreateTable(
                name: "income_expense_category",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Type = table.Column<string>(type: "char(3)", nullable: false),
                    IsFixed = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_expense_category", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "household_account_month",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_household_account_month", x => x.Id);
                    table.ForeignKey(
                        name: "FK_household_account_month_household_account_book_Year",
                        column: x => x.Year,
                        principalTable: "household_account_book",
                        principalColumn: "Year");
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

            migrationBuilder.CreateTable(
                name: "wallet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonthId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Budget = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wallet_household_account_month_MonthId",
                        column: x => x.MonthId,
                        principalTable: "household_account_month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "income_expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonthId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false, defaultValue: 1m),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CategoryPositionId = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    WalletId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_income_expense_household_account_month_MonthId",
                        column: x => x.MonthId,
                        principalTable: "household_account_month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_income_expense_income_expense_category_position_CategoryPositionId",
                        column: x => x.CategoryPositionId,
                        principalTable: "income_expense_category_position",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_income_expense_wallet_WalletId",
                        column: x => x.WalletId,
                        principalTable: "wallet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "income_expense_position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IncomeExpenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: false, defaultValue: 1m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_income_expense_position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_income_expense_position_income_expense_IncomeExpenseId",
                        column: x => x.IncomeExpenseId,
                        principalTable: "income_expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_household_account_month_Year",
                table: "household_account_month",
                column: "Year");

            migrationBuilder.CreateIndex(
                name: "IX_income_expense_CategoryPositionId",
                table: "income_expense",
                column: "CategoryPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_income_expense_MonthId",
                table: "income_expense",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_income_expense_WalletId",
                table: "income_expense",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_income_expense_category_position_CategoryName",
                table: "income_expense_category_position",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_income_expense_position_IncomeExpenseId",
                table: "income_expense_position",
                column: "IncomeExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_MonthId",
                table: "wallet",
                column: "MonthId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "income_expense_position");

            migrationBuilder.DropTable(
                name: "income_expense");

            migrationBuilder.DropTable(
                name: "income_expense_category_position");

            migrationBuilder.DropTable(
                name: "wallet");

            migrationBuilder.DropTable(
                name: "income_expense_category");

            migrationBuilder.DropTable(
                name: "household_account_month");

            migrationBuilder.DropTable(
                name: "household_account_book");
        }
    }
}
