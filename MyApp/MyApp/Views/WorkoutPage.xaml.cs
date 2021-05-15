using MyApp.Models;
using MyApp.ViewModels;
using System;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
            //BindingContext = new WorkoutPageViewModel();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as Workout;
            await Navigation.PushAsync(new WorkoutDetailPage(details.Name, details.Image, details.ImageDetail, details.Instructions));
        }
    }
}
