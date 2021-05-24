using MyApp.Tables;
using MyApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Xaml;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private App app;
        public LoginPageViewModel()
        {

        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Command LoginCommand  
        {  
            get  
            {  
                return new Command(Login);  
            }  
        }

        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private async void Register()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }

        private void Login()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(Username) && u.Password.Equals(Password)).FirstOrDefault();

            if (myquery != null)
            {
                var fpm = new MasterDetailPage()
                {
                    Master = new MainTabbedPage(),
                    Detail = new NavigationPage(new HomePage())

                };

                //Navigation.InsertPageBefore(new HomePage(), this);
                App.Current.MainPage = fpm;
                //await Navigation.PopToRootAsync();
                //return;
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await App.Current.MainPage.DisplayAlert("Error", "Failed User Name and Password", "Yes", "Cancel");

                    if (result)
                        await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    else
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                });
            }

        }


    }
}
