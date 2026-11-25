

namespace MoneyMate.Core.Entities
{
    public class Account
    {
        public string Name { get; private set; }
        public string AccountGroupName { get; private set; }
        public AccountGroup AccountGroup { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; set; } = new List<IncomeExpense>();

        private Account() { }

        public Account(string name, AccountGroup accountGroup)
        {
            Name = name;
            AccountGroupName = accountGroup.Name;
            AccountGroup = accountGroup;
        }
    }
}
