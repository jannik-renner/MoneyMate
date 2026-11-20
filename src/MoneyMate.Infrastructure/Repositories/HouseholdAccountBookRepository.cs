

using Microsoft.EntityFrameworkCore;
using MoneyMate.Domain.Entities;
using MoneyMate.Infrastructure.Persistance;

namespace MoneyMate.Infrastructure.Repositories
{
    public class HouseholdAccountBookRepository
    {
        private readonly AppDbContext _dbContext;

        public HouseholdAccountBookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Loads a List of all HouseholdAccountBooks as NoTracking.
        /// Includes no other data
        /// </summary>
        /// <returns></returns>
        public async Task<List<HouseholdAccountBook>> Get()
        {
            return await _dbContext.HouseholdAccountBook.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Loads the entire HouseholdAccountBook.
        /// Includes HouseholdAccountMonth and IncomeExpense informations as NoTracking.
        /// Returns null when the HouseholdAccountBook does not exist
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<HouseholdAccountBook?> GetByYear(int year)
        {
            return await _dbContext.HouseholdAccountBook.Where(x => x.Year == year)
                .Include(x => x.Months)
                    .ThenInclude(m => m.Wallets)
                        .ThenInclude(w => w.IncomeExpenses)
                            .ThenInclude(ie => ie.CategoryPosition)
                                .ThenInclude(cp => cp.Category)
                .Include(x => x.Months)
                    .ThenInclude(m => m.IncomeExpenses)
                        .ThenInclude(ie => ie.CategoryPosition)
                            .ThenInclude(cp => cp.Category)
                .Include(x => x.Months)
                    .ThenInclude(m => m.HouseholdAccountBook)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Loads a HouseholdAccountMonth by monthId as NoTracking.
        /// Includes IncomeExpenses and their CategoryPositions with their Category object.
        /// Returns null when the month does not exist
        /// </summary>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public async Task<HouseholdAccountMonth?> GetHouseholdAccountMonthById(int monthId)
        {
            return await _dbContext.Months.Where(x => x.Id == monthId).AsNoTracking()
                .Include(m => m.IncomeExpenses)
                    .ThenInclude(ie => ie.CategoryPosition)
                        .ThenInclude(cp => cp.Category)
                .FirstOrDefaultAsync();
        }
    }
}
