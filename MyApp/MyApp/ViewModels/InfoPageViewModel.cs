using MyApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class InfoPageViewModel : ViewModelBase
    {
        public InfoPageViewModel(INavigationService navigationService, IFileHelper helper)
        : base(navigationService)
        {
            info = helper.GetFileContent();
        }

        private string info;

        public string Info
        {
            get { return info; }
            set { info = value;}
        }
    }
}
