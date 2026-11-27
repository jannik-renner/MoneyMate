

namespace MoneyMate.Core.Entities
{
    public class Account
    {
        public const string DefaultExpensesAccountName = "Sonstige Ausgaben";
        public const string DefaultIncomeAccountName = "Sonstige Einnahmen";


        public string Name { get; private set; }
        public string AccountGroupName { get; private set; }
        public AccountGroup AccountGroup { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; set; } = new List<IncomeExpense>();
        public bool CanBeDeleted { get; private set; }

        private Account() { }

        public Account(string name, AccountGroup accountGroup)
        {
            Name = name;
            AccountGroupName = accountGroup.Name;
            AccountGroup = accountGroup;
            CanBeDeleted = true;
        }

        public Account(string name, AccountGroup accountGroup, bool canBeDeleted)
        {
            Name = name;
            AccountGroupName = accountGroup.Name;
            AccountGroup = accountGroup;
            CanBeDeleted = canBeDeleted;
        }

        public Account(string name, string accountGroupName, bool canBeDeleted)
        {
            Name = name;
            AccountGroupName = accountGroupName;
            CanBeDeleted = canBeDeleted;
        }


        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Account acc &&
                Name == acc.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
