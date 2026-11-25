

namespace MoneyMate.Core.Entities
{
    public class IncomeExpense
    {
        public int Id { get; private set; }
        public int MonthId { get; private set; }
        public HouseholdAccountMonth? Month { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Quantity { get; private set; }
        public DateTime Date { get; private set; }
        public string AccountId { get; private set; }
        public Account Account { get; private set; }
        public List<IncomeExpensePosition> Positions { get; private set; } = new List<IncomeExpensePosition>();
        public int? WalletId { get; private set; }
        public Wallet? Wallet { get; private set; }

        private IncomeExpense() { }

        public IncomeExpense(HouseholdAccountMonth month, string description, decimal amount, DateTime date, Account account)
        {
            MonthId = month.Id;
            Month = month;
            Description = description;
            Amount = amount;
            Quantity = 1;
            Date = date;
            AccountId = account.Name;
            Account = account;
        }

        public IncomeExpense(HouseholdAccountMonth month, string description, decimal amount, decimal quantity, DateTime date, Account account)
        {
            MonthId = month.Id;
            Month = month;
            Description = description;
            Amount = amount;
            Quantity = quantity;
            Date = date;
            AccountId = account.Name;
            Account = account;
        }

        /// <summary>
        /// Checks if the given position is already contained in the Position collection. 
        /// If not it will add the position and calcualte the total amount from each position.
        /// True is returned when successfully adding the position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool AddPosition(IncomeExpensePosition position)
        {
            if (!Positions.Contains(position))
            {
                Positions.Remove(position);
                Amount = Positions.Sum(x => x.Amount * x.Quantity);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the given position is already contained in the Position collection. 
        /// If contained, it will remove the position and calcualte the total amount from each position.
        /// True is returned when successfully removing the position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool RemovePosition(IncomeExpensePosition position)
        {
            if (Positions.Contains(position))
            {
                Positions.Remove(position);
                Amount = Positions.Sum(x => x.Amount * x.Quantity);
                return true;
            }
            return false;
        }
    }
}
