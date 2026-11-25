

namespace MoneyMate.Core.Entities
{
    public class AccountGroup
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public IncomeExpenseType? Type { get; private set; }
        public bool IsFixed { get; private set; }
        public List<Account> Accounts { get; private set; } = new List<Account>();

        private AccountGroup() { }

        public AccountGroup(string name, string description, IncomeExpenseType type, bool isFixed)
        {
            Name = name;
            Description = description;
            Type = type;
            IsFixed = isFixed;
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
