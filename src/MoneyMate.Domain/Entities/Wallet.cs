

namespace MoneyMate.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; private set; }
        public int MonthId { get; set; }
        public Month? Month { get; private set; }
        public string Name { get; private set; }
        public decimal Budget { get; private set; }
        public List<IncomeExpense> IncomeExpenses { get; private set; } = new List<IncomeExpense>();


        private Wallet() { }

        public Wallet(Month month, string name, decimal budget)
        {
            Month = month;
            Name = name;
            Budget = budget;
        }
    }
}
