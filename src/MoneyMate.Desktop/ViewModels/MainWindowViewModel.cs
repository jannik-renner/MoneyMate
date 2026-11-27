using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyMate.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainWindowViewModel()
        {
            CurrentViewModel = new MainViewViewModel();
        }
    }
}

// https://www.youtube.com/watch?v=fZxZswmC_BY&list=PLA8ZIAm2I03hS41Fy4vFpRw8AdYNBXmNm&index=1