using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class WorkoutPageViewModel : ViewModelBase
    {
        public WorkoutPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Workout";
        }
    }
}
