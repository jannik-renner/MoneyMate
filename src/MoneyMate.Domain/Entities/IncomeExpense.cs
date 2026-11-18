

namespace MoneyMate.Domain.Entities
{
    public class IncomeExpense
    {
        public int Id { get; private set; }
        public int MonthId { get; private set; }
        public Month? Month { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Quantity { get; private set; }
        public DateTime Date { get; private set; }
        public string CategoryPosition { get; private set; }
        public IncomeExpenseCategoryPosition CategoryPositionNavigation { get; private set; }
        public List<IncomeExpensePosition> Positions { get; private set; } = new List<IncomeExpensePosition>();
        public int? WalletId { get; private set; }
        public Wallet? Wallet { get; private set; }

        private IncomeExpense() { }

        public IncomeExpense(Month month, string description, decimal amount, DateTime date, IncomeExpenseCategoryPosition categoryPosition)
        {
            MonthId = month.Id;
            Month = month;
            Description = description;
            Amount = amount;
            Quantity = 1;
            Date = date;
            CategoryPosition = categoryPosition.Name;
            CategoryPositionNavigation = categoryPosition;
        }

        public IncomeExpense(Month month, string description, decimal amount, decimal quantity, DateTime date, IncomeExpenseCategoryPosition categoryPosition)
        {
            MonthId = month.Id;
            Month = month;
            Description = description;
            Amount = amount;
            Quantity = quantity;
            Date = date;
            CategoryPosition = categoryPosition.Name;
            CategoryPositionNavigation = categoryPosition;
        }
    }
}
