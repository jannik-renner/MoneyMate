using Microsoft.EntityFrameworkCore;

namespace MoneyMate.Infrastructure.DbContextSettings
{
    public class DatabaseInitializer
    {
        private readonly AppDbContext _dbContext;

        public DatabaseInitializer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
