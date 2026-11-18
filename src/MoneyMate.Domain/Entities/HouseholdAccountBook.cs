
namespace MoneyMate.Domain.Entities
{
    public class HouseholdAccountBook
    {
        public int Year { get; private set; }
        public List<Month> Months { get; private set; } = new List<Month>();

        private HouseholdAccountBook() { }

        public HouseholdAccountBook(int year)
        {
            Year = year;
            Months.Add(new Month(this, 1, "Januar"));
            Months.Add(new Month(this, 2, "Februar"));
            Months.Add(new Month(this, 3, "März"));
            Months.Add(new Month(this, 4, "April"));
            Months.Add(new Month(this, 5, "Mai"));
            Months.Add(new Month(this, 6, "Juni"));
            Months.Add(new Month(this, 7, "Juli"));
            Months.Add(new Month(this, 8, "August"));
            Months.Add(new Month(this, 9, "September"));
            Months.Add(new Month(this, 10, "Oktober"));
            Months.Add(new Month(this, 11, "November"));
            Months.Add(new Month(this, 12, "Dezember"));
        }
    }
}
