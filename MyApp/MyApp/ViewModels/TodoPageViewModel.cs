using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class TodoPageViewModel : ViewModelBase
    {
        public TodoPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Todo";
        }
    }
}
