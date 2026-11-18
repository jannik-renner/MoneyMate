

namespace MoneyMate.Domain.Entities
{
    public class Month
    {
        public int Id { get; private set; }
        public int Year { get; private set; }
        public HouseholdAccountBook? HouseholdAccountBook { get; private set; }
        public int MonthNumber { get; private set; }
        public string Name { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; private set; } = new List<IncomeExpense>();
        public List<Wallet> Wallets { get; private set; } = new List<Wallet>();

        private Month() { }

        public Month(HouseholdAccountBook householdAccountBook, int monthNumber, string name)
        {
            Year = householdAccountBook.Year;
            HouseholdAccountBook = householdAccountBook;
            MonthNumber = monthNumber;
            Name = name;
        }
    }
}
