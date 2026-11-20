using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MoneyMate.Core;

namespace MoneyMate.Infrastructure.DbContextSettings
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlite(DatabaseSetup.DatabaseDesktopPath);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
