

namespace MoneyMate.Domain.Entities
{
    public class IncomeExpenseCategory
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public IncomeExpenseType? Type { get; private set; }
        public bool IsFixed { get; private set; }
        public List<IncomeExpenseCategoryPosition> Positions { get; private set; } = new List<IncomeExpenseCategoryPosition>();

        private IncomeExpenseCategory() { }

        public IncomeExpenseCategory(string name, string description, IncomeExpenseType type, bool isFixed)
        {
            Name = name;
            Description = description;
            Type = type;
            IsFixed = isFixed;
        }

        public void AddPosition(IncomeExpenseCategoryPosition position)
        {
            if(!Positions.Any(p => p.Name.Equals(position.Name) && p.Category.Name.Equals(position.Category.Name)))
                Positions.Add(position);
        }

        public void RemovePosition(IncomeExpenseCategoryPosition position)
        {
            if (Positions.Any(p => p.Name.Equals(position.Name) && p.Category.Name.Equals(position.Category.Name)))
                Positions.Remove(position);
        }
    }
}
