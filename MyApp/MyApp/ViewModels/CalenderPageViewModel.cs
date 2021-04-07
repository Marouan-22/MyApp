using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class CalenderPageViewModel : ViewModelBase
    {
        public CalenderPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Calender";
        }
    }
}
