

using System.Windows.Input;

namespace MoneyMate.Desktop.ViewModels
{
    public class NewHouseholdAccountBookViewModel : ViewModelBase
    {
        private int _year;
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year =value;
                OnPropertyChanged(nameof(Year));
            }
        }


        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }


        public NewHouseholdAccountBookViewModel()
        {

        }
    }
}
