using Microsoft.EntityFrameworkCore;
using MoneyMate.Core.Entities;
using MoneyMate.Core.Interfaces.Repositories;
using MoneyMate.Infrastructure.DbContextSettings;

namespace MoneyMate.Infrastructure.Repositories
{
    public class WalletRepository : IIWalletRepository
    {
        private readonly AppDbContext _dbContext;

        public WalletRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Loads all Wallets by given monthId. 
        /// Includes IncomeExpenses
        /// </summary>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public async Task<List<Wallet>> GetByMonth(int monthId)
        {
            return await _dbContext.Wallets.Where(x => x.MonthId == monthId)
                .Include(w => w.IncomeExpenses)
                .AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Adds the Wallet object to the dbContext and saves it
        /// </summary>
        /// <param name="wallet"></param>
        public async void Create(Wallet wallet)
        {
            _dbContext.Add(wallet);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(Wallet wallet)
        {
            _dbContext.Wallets.Update(wallet);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(Wallet wallet)
        {
            _dbContext.Wallets.Remove(wallet);
            await _dbContext.SaveChangesAsync();
        }
    }
}
