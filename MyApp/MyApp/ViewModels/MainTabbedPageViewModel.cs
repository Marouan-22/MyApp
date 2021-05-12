using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class MainTabbedPageViewModel : ViewModelBase
    {
        public MainTabbedPageViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            Title = "MaSa";

            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecuted);
        }
        public DelegateCommand<string> NavigateCommand { get; }

        private async void NavigateCommandExecuted(string path)
        {
            await NavigationService.NavigateAsync($"NavigationPage/{path}");
        }
    }
}
