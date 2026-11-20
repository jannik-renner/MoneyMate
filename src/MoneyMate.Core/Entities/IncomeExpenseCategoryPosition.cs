

namespace MoneyMate.Core.Entities
{
    public class IncomeExpenseCategoryPosition
    {
        public string Name { get; private set; }
        public string CategoryName { get; private set; }
        public IncomeExpenseCategory Category { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; set; } = new List<IncomeExpense>();

        private IncomeExpenseCategoryPosition() { }

        public IncomeExpenseCategoryPosition(string name, IncomeExpenseCategory category)
        {
            Name = name;
            CategoryName = category.Name;
            Category = category;
        }
    }
}
