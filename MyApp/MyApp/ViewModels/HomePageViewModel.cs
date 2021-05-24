using MyApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Home";
        }

        public Command InfoCommand
        {
            get
            {
                return new Command(Info);
            }
        }

        private async void Info()
        {
            await NavigationService.NavigateAsync(nameof(InfoPage));
        }
    }
}
