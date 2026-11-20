

using Microsoft.EntityFrameworkCore;
using MoneyMate.Core.Entities;
using MoneyMate.Infrastructure.Persistance;

namespace MoneyMate.Infrastructure.Repositories
{
    public class IncomeExpenseRepository
    {
        private readonly AppDbContext _dbContext;

        public IncomeExpenseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Adds the IncomeExpense object to the dbContext and saves it
        /// </summary>
        /// <param name="incomeExpense"></param>
        public async void Create(IncomeExpense incomeExpense)
        {
            _dbContext.Add(incomeExpense);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(IncomeExpense incomeExpense)
        {
            _dbContext.IncomeExpenses.Update(incomeExpense);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(IncomeExpense incomeExpense)
        {
            _dbContext.Remove(incomeExpense);
            await _dbContext.SaveChangesAsync();
        }


        /// <summary>
        /// Adds the IncomeExpensePosition object to the dbContext and saves it
        /// </summary>
        /// <param name="incomeExpense"></param>
        public async void Create(IncomeExpensePosition incomeExpensePosition)
        {
            _dbContext.Add(incomeExpensePosition);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update(IncomeExpensePosition incomeExpensePosition)
        {
            _dbContext.IncomeExpensePositions.Update(incomeExpensePosition);
            await _dbContext.SaveChangesAsync();
        }

        public async void Delete(IncomeExpensePosition incomeExpensePosition)
        {
            _dbContext.Remove(incomeExpensePosition);
            await _dbContext.SaveChangesAsync();
        }



        public async Task<decimal> TotalIncome(int monthId) => await CalculateTotal(monthId, IncomeExpenseType.Income);
        public async Task<decimal> TotalIncomeFixed(int monthId) => await CalculateTotal(monthId, IncomeExpenseType.Income, true);
        public async Task<decimal> TotalIncomeVariable(int monthId) => await CalculateTotal(monthId, IncomeExpenseType.Income, false);

        public async Task<decimal> TotalExpense(int monthId) => await CalculateTotal(monthId, IncomeExpenseType.Expense);
        public async Task<decimal> TotalExpenseFixed(int monthId) => await CalculateTotal(monthId, IncomeExpenseType.Expense, true);
        public async Task<decimal> TotalExpenseVariable(int monthId) => await CalculateTotal(monthId, IncomeExpenseType.Expense, false);
        public async Task<decimal> Balance(int monthId)
        {
            return await TotalIncome(monthId) - await TotalExpense(monthId);
        }

        private async Task<decimal> CalculateTotal(int monthId, IncomeExpenseType type, bool? isFixed = null)
        {
            return await _dbContext.IncomeExpenses
                .Where(x =>
                    x.CategoryPosition.Category.Type == type &&
                    (!isFixed.HasValue || x.CategoryPosition.Category.IsFixed == isFixed.Value) &&
                    x.MonthId == monthId)
                .SumAsync(x => x.Amount * x.Quantity);
        }
    }
}
