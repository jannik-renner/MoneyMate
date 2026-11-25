using Microsoft.EntityFrameworkCore;
using MoneyMate.Core.Entities;

namespace MoneyMate.Infrastructure.DbContextSettings
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<HouseholdAccountBook> HouseholdAccountBook => Set<HouseholdAccountBook>();
        public DbSet<HouseholdAccountMonth> Months => Set<HouseholdAccountMonth>();
        public DbSet<AccountGroup> AccountGroups => Set<AccountGroup>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Wallet> Wallets => Set<Wallet>();
        public DbSet<IncomeExpense> IncomeExpenses => Set<IncomeExpense>();
        public DbSet<IncomeExpensePosition> IncomeExpensePositions => Set<IncomeExpensePosition>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // HouseholdAccountBook
            modelBuilder.Entity<HouseholdAccountBook>(entity =>
            {
                entity.ToTable("household_account_book");

                entity.HasKey(e => e.Year);

                entity.Property(e => e.CreatedTimestamp)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.ChangedTimestamp)
                    .HasColumnType("datetime");
            });

            // HouseholdAccountMonth
            modelBuilder.Entity<HouseholdAccountMonth>(entity =>
            {
                entity.ToTable("household_account_month");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MonthNumber)
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasMaxLength(24)
                    .IsRequired();

                entity.HasOne(e => e.HouseholdAccountBook)
                    .WithMany(e => e.Months)
                    .HasForeignKey(e => e.Year)
                    .IsRequired(false);
            });

            // AccountGroup
            modelBuilder.Entity<AccountGroup>(entity =>
            {
                entity.ToTable("account_group");

                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(128);

                // Convert enum to CHAR(3)
                entity.Property(e => e.Type)
                    .HasColumnType("char(3)")
                    .HasConversion(
                        value => value == IncomeExpenseType.Income
                            ? "INC"
                            : "EXP",
                        value => value == "INC"
                            ? IncomeExpenseType.Income
                            : IncomeExpenseType.Expense)
                    .IsRequired();

                entity.Property(e => e.IsFixed)
                    .HasDefaultValue(false);

                entity.Property(e => e.CanBeDeleted)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.HouseholdAccountBookId)
                    .IsRequired(false);

                entity.HasOne(e =>  e.HouseholdAccountBook)
                     .WithMany(e => e.AccountGroups)
                     .HasForeignKey(e => e.HouseholdAccountBookId)
                     .IsRequired(false);

                // Default entries
                entity.HasData(
                    new AccountGroup(AccountGroup.DefaultExpensesGroupName, "Sonstige monatliche Ausgaben", IncomeExpenseType.Expense, false, false),
                    new AccountGroup(AccountGroup.DefaultIncomeGroupName, "Sonstige monatliche Einnahmen", IncomeExpenseType.Income, false, false)
                );
            });

            // Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.AccountGroupName)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.HasOne(e => e.AccountGroup)
                    .WithMany(e => e.Accounts)
                    .HasForeignKey(e => e.AccountGroupName)
                    .IsRequired();

                entity.Property(e => e.CanBeDeleted)
                    .IsRequired()
                    .HasDefaultValue(true);

                // Default entries
                entity.HasData(
                    new Account(Account.DefaultExpensesAccountName, AccountGroup.DefaultExpensesGroupName, false),
                    new Account(Account.DefaultIncomeAccountName, AccountGroup.DefaultIncomeGroupName, false)
                );
            });

            // Wallet
            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("wallet");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.Budget)
                    .HasPrecision(12, 2)
                    .HasDefaultValue(0m);

                entity.HasOne(e => e.Month)
                    .WithMany(e => e.Wallets)
                    .HasForeignKey(e => e.MonthId)
                    .IsRequired();
            });

            // IncomeExpense
            modelBuilder.Entity<IncomeExpense>(entity =>
            {
                entity.ToTable("income_expense");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.AccountId)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.Amount)
                    .HasPrecision(12, 2)
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .HasPrecision(12, 2)
                    .HasDefaultValue(1m);

                entity.HasOne(e => e.Month)
                    .WithMany(e => e.IncomeExpenses)
                    .HasForeignKey(e => e.MonthId)
                    .IsRequired();

                entity.HasOne(e => e.Account)
                    .WithMany(e => e.IncomeExpenses)
                    .HasForeignKey(e => e.AccountId)
                    .IsRequired();

                entity.HasOne(e => e.Wallet)
                    .WithMany(e => e.IncomeExpenses)
                    .HasForeignKey(e => e.WalletId)
                    .IsRequired(false);
            });

            // IncomeExpensePosition
            modelBuilder.Entity<IncomeExpensePosition>(entity =>
            {
                entity.ToTable("income_expense_position");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.Property(e => e.Amount)
                    .HasPrecision(12, 2)
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .HasPrecision(12, 2)
                    .HasDefaultValue(1m);

                entity.HasOne(e => e.IncomeExpense)
                    .WithMany(e => e.Positions)
                    .HasForeignKey(e => e.IncomeExpenseId)
                    .IsRequired();
            });
        }
    }
}
