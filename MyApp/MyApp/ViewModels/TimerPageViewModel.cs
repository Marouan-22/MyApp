using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class TimerPageViewModel : ViewModelBase
    {
        public TimerPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Timer";
        }

    }
}
