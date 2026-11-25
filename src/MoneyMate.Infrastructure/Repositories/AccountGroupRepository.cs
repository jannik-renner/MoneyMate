using Microsoft.EntityFrameworkCore;
using MoneyMate.Core.Entities;
using MoneyMate.Core.Interfaces.Repositories;
using MoneyMate.Infrastructure.DbContextSettings;

namespace MoneyMate.Infrastructure.Repositories
{
    public class AccountGroupRepository : IAccountGroupRepository
    {
        private readonly AppDbContext _dbContext;

        public AccountGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Loads all IncomeExpenseCategories
        /// Includes all IncomeExpenseCategoryPositions
        /// </summary>
        /// <returns></returns>
        public async Task<List<AccountGroup>> GetFull()
        {
            return await _dbContext.AccountGroups
                .Include(x => x.Accounts)
                .AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Adds the IncomeExpenseCategory object to the dbContext and saves it
        /// </summary>
        /// <param name="category"></param>
        public async void Create(AccountGroup category)
        {
            _dbContext.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(AccountGroup category)
        {
            _dbContext.AccountGroups.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(AccountGroup category)
        {
            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds the IncomeExpenseCategoryPosition object to the dbContext and saves it
        /// </summary>
        /// <param name="account"></param>
        public async void Create(Account account)
        {
            _dbContext.Add(account);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(Account account)
        {
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(Account account)
        {
            _dbContext.Remove(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}
