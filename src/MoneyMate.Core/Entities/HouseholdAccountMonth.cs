
namespace MoneyMate.Core.Entities
{
    public class HouseholdAccountMonth
    {
        public int Id { get; private set; }
        public int Year { get; private set; }
        public HouseholdAccountBook? HouseholdAccountBook { get; private set; }
        public int MonthNumber { get; private set; }
        public string Name { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; private set; } = new List<IncomeExpense>();
        public List<Wallet> Wallets { get; private set; } = new List<Wallet>();

        #region Calcualted Fields
        /// <summary>
        /// Returns the total income of the current month
        /// </summary>
        /// <returns></returns>
        public decimal TotalIncome => CalculateTotal(IncomeExpenseType.Income);

        /// <summary>
        /// Returns the total fixed income of the current month
        /// </summary>
        /// <returns></returns>
        public decimal TotalIncomeFixed => CalculateTotal(IncomeExpenseType.Income, true);

        /// <summary>
        /// Returns the total variable income of the current month
        /// </summary>
        /// <returns></returns>
        public decimal TotalIncomeVariable => CalculateTotal(IncomeExpenseType.Income, false);

        /// <summary>
        /// Returns the total expense of the current month
        /// </summary>
        /// <returns></returns>
        public decimal TotalExpense => CalculateTotal(IncomeExpenseType.Expense);

        /// <summary>
        /// Returns the total fixed expense of the current month
        /// </summary>
        /// <returns></returns>
        public decimal TotalExpenseFixed => CalculateTotal(IncomeExpenseType.Expense, true);

        /// <summary>
        /// Returns the total variable expense of the current month
        /// </summary>
        /// <returns></returns>
        public decimal TotalExpenseVariable => CalculateTotal(IncomeExpenseType.Expense, false);

        /// <summary>
        /// Returns the balance of the current month (TotalIncome - TotalExpense)
        /// </summary>
        /// <returns></returns>
        public decimal Balance => TotalIncome - TotalExpense;
        #endregion

        private HouseholdAccountMonth() { }

        public HouseholdAccountMonth(HouseholdAccountBook householdAccountBook, int monthNumber, string name)
        {
            Year = householdAccountBook.Year;
            HouseholdAccountBook = householdAccountBook;
            MonthNumber = monthNumber;
            Name = name;
        }

        #region Calculations
        private decimal CalculateTotal(IncomeExpenseType type, bool? isFixed = null)
        {
            return IncomeExpenses
                .Where(x =>
                    x.CategoryPosition.Category.Type == type &&
                    (!isFixed.HasValue || x.CategoryPosition.Category.IsFixed == isFixed.Value))
                .Sum(x => x.Amount * x.Quantity);
        }

        /// <summary>
        /// Returns the total income or expense amount by category and type of the current month
        /// </summary>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public decimal TotalAmountByCategoryAndTypeCalc(string category, IncomeExpenseType type)
        {
            if (IncomeExpenses.Count == 0)
            {
                return 0;
            }
            return IncomeExpenses
                .Where(x => x.CategoryPosition.Category.Name.Equals(category)
                    && x.CategoryPosition.Category.Type == type)
                .Sum(x => x.Amount * x.Quantity);
        }

        /// <summary>
        /// Returns the total income or expense amount by category and type of the current month
        /// </summary>
        /// <param name="categoryPosition"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public decimal TotalAmountByCategoryPositionAndType(string categoryPosition, IncomeExpenseType type)
        {
            if (IncomeExpenses.Count == 0)
            {
                return 0;
            }
            return IncomeExpenses
                .Where(x => x.CategoryPosition.Name.Equals(categoryPosition)
                    && x.CategoryPosition.Category.Type == type)
                .Sum(x => x.Amount * x.Quantity);
        }
        #endregion
    }
}
