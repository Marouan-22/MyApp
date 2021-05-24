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
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class RegistrationPageViewModel : BindableBase
    {
        public RegistrationPageViewModel()
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

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private void Register()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = username,
                Password = password,
                Email = email,
                PhoneNumber = phone
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await App.Current.MainPage.DisplayAlert("Congratulation", "User Registeration Sucessfull", "Yes", "Cancel");

                if (result)
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            });

        }

    }
}
