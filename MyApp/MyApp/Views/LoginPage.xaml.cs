using MyApp.Tables;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private App app;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void Button_Clicked_1(object sender, System.EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegUserTable>().Where(u => u.UserName.Equals(EntryUser.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

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
                    var result = await this.DisplayAlert("Error", "Failed User Name and Password", "Yes", "Cancel");

                    if (result)
                        await Navigation.PushAsync(new LoginPage());
                    else
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
                });
            }

        }
    }
}
