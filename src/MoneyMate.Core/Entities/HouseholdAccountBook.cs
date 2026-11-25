
namespace MoneyMate.Core.Entities
{
    public class HouseholdAccountBook
    {
        public int Year { get; private set; }
        public List<HouseholdAccountMonth> Months { get; private set; } = new List<HouseholdAccountMonth>();
        public List<AccountGroup> AccountGroups { get; private set; } = new List<AccountGroup>();
        public DateTime CreatedTimestamp { get; private set; }
        public DateTime? ChangedTimestamp { get; private set; }

        private HouseholdAccountBook() { }

        public HouseholdAccountBook(int year)
        {
            Year = year;
            Months.Add(new HouseholdAccountMonth(this, 1, "Januar"));
            Months.Add(new HouseholdAccountMonth(this, 2, "Februar"));
            Months.Add(new HouseholdAccountMonth(this, 3, "März"));
            Months.Add(new HouseholdAccountMonth(this, 4, "April"));
            Months.Add(new HouseholdAccountMonth(this, 5, "Mai"));
            Months.Add(new HouseholdAccountMonth(this, 6, "Juni"));
            Months.Add(new HouseholdAccountMonth(this, 7, "Juli"));
            Months.Add(new HouseholdAccountMonth(this, 8, "August"));
            Months.Add(new HouseholdAccountMonth(this, 9, "September"));
            Months.Add(new HouseholdAccountMonth(this, 10, "Oktober"));
            Months.Add(new HouseholdAccountMonth(this, 11, "November"));
            Months.Add(new HouseholdAccountMonth(this, 12, "Dezember"));
            CreatedTimestamp = DateTime.Now;
        }
    }
}
