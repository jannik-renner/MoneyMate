

using Microsoft.EntityFrameworkCore;
using MoneyMate.Core.Entities;
using MoneyMate.Infrastructure.Persistance;

namespace MoneyMate.Infrastructure.Repositories
{
    public class IncomeExpenseCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public IncomeExpenseCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Loads all IncomeExpenseCategories
        /// Includes all IncomeExpenseCategoryPositions
        /// </summary>
        /// <returns></returns>
        public async Task<List<IncomeExpenseCategory>> GetFull()
        {
            return await _dbContext.IncomeExpenseCategories
                .Include(x => x.Positions)
                .AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Adds the IncomeExpenseCategory object to the dbContext and saves it
        /// </summary>
        /// <param name="category"></param>
        public async void Create(IncomeExpenseCategory category)
        {
            _dbContext.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(IncomeExpenseCategory category)
        {
            _dbContext.IncomeExpenseCategories.Update(category);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(IncomeExpenseCategory category)
        {
            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds the IncomeExpenseCategoryPosition object to the dbContext and saves it
        /// </summary>
        /// <param name="categoryPosition"></param>
        public async void Create(IncomeExpenseCategoryPosition categoryPosition)
        {
            _dbContext.Add(categoryPosition);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(IncomeExpenseCategoryPosition categoryPosition)
        {
            _dbContext.IncomeExpenseCategoryPositions.Update(categoryPosition);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(IncomeExpenseCategoryPosition categoryPosition)
        {
            _dbContext.Remove(categoryPosition);
            await _dbContext.SaveChangesAsync();
        }
    }
}
