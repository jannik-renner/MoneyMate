

namespace MoneyMate.Core.Entities
{
    public class Wallet
    {
        public int Id { get; private set; }
        public int MonthId { get; set; }
        public HouseholdAccountMonth? Month { get; private set; }
        public string Name { get; private set; }
        public decimal Budget { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; private set; } = new List<IncomeExpense>();


        private Wallet() { }

        public Wallet(HouseholdAccountMonth month, string name, decimal budget)
        {
            Month = month;
            Name = name;
            Budget = budget;
        }

        #region Calculations
        /// <summary>
        /// Returns the total expense of this wallet by connected month
        /// </summary>
        /// <param name="walletId"></param>
        /// <returns></returns>
        public decimal TotalExpense()
        {
            if (IncomeExpenses.Count == 0)
            {
                return 0;
            }

            return IncomeExpenses
                .Where(x => x.Account.AccountGroup.Type == IncomeExpenseType.Expense
                    && x.Date.Month == Month!.MonthNumber && x.Date.Year == Month!.Year)
                .Sum(x => x.Amount * x.Quantity);
        }
        #endregion
    }
}
