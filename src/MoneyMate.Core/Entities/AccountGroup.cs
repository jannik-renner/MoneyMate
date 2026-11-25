

namespace MoneyMate.Core.Entities
{
    public class AccountGroup
    {
        public const string DefaultExpensesGroupName = "Sonstige Ausgaben";
        public const string DefaultIncomeGroupName = "Sonstige Einnahmen";


        public string Name { get; private set; }
        public string? Description { get; private set; }
        public IncomeExpenseType? Type { get; private set; }
        public bool IsFixed { get; private set; }
        public List<Account> Accounts { get; private set; } = new List<Account>();
        public bool CanBeDeleted { get; private set; }
        public int? HouseholdAccountBookId { get; private set; }
        public HouseholdAccountBook? HouseholdAccountBook { get; private set; }


        private AccountGroup() { }

        public AccountGroup(string name, string description, IncomeExpenseType type, bool isFixed, int? householdAccountBookId = null)
        {
            Name = name;
            Description = description;
            Type = type;
            IsFixed = isFixed;
            CanBeDeleted = true;
            HouseholdAccountBookId = householdAccountBookId;
        }
        public AccountGroup(string name, string description, IncomeExpenseType type, bool isFixed, bool canBeDeleted, int? householdAccountBookId = null)
        {
            Name = name;
            Description = description;
            Type = type;
            IsFixed = isFixed;
            CanBeDeleted = canBeDeleted;
            HouseholdAccountBookId = householdAccountBookId;
        }

        public void AddAccount(Account position)
        {
            if(!Accounts.Any(p => p.Name.Equals(position.Name) && p.AccountGroup.Name.Equals(position.AccountGroup.Name)))
                Accounts.Add(position);
        }

        public void RemoveAccount(Account position)
        {
            if (Accounts.Any(p => p.Name.Equals(position.Name) && p.AccountGroup.Name.Equals(position.AccountGroup.Name)))
                Accounts.Remove(position);
        }
    }
}
