using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyMate.Core.Interfaces.Repositories;
using MoneyMate.Infrastructure.DbContextSettings;
using MoneyMate.Infrastructure.Repositories;

namespace MoneyMate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string databasePath)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));
            services.AddScoped<DatabaseInitializer>();

            services.AddScoped<IBalanceRepository, BalanceRepository>();
            services.AddScoped<IHouseholdAccountBookRepository, HouseholdAccountBookRepository>();
            services.AddScoped<IIncomeExpenseRepository, IncomeExpenseRepository>();
            services.AddScoped<IIncomeExpenseCategoryRepository, IncomeExpenseCategoryRepository>();
            services.AddScoped<IIWalletRepository, WalletRepository>();
            return services;
        }
    }
}
