

namespace MoneyMate.Domain.Entities
{
    public class IncomeExpensePosition
    {
        public int Id { get; private set; }
        public int IncomeExpenseId { get; private set; }
        public IncomeExpense? IncomeExpense { get; private set; }
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Quantity { get; private set; }

        private IncomeExpensePosition() { }
        public IncomeExpensePosition(IncomeExpense incomeExpense, string description, decimal amount)
        {
            IncomeExpenseId = incomeExpense.Id;
            IncomeExpense = incomeExpense;
            Description = description;
            Amount = amount;
            Quantity = 1;
        }
        public IncomeExpensePosition(IncomeExpense incomeExpense, string description, decimal amount, decimal quantity)
        {
            IncomeExpenseId = incomeExpense.Id;
            IncomeExpense = incomeExpense;
            Description = description;
            Amount = amount;
            Quantity = quantity;
        }
    }
}
