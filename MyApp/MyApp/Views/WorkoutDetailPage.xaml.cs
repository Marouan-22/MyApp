using System;
using System.IO;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class WorkoutDetailPage : ContentPage
    {
        public WorkoutDetailPage(string Name, string source, string exersice, string Instructions)
        {
            InitializeComponent();
            MyItemNameShow.Text = Name;
            MyImageCall.Source = ImageSource.FromFile(source);
            MyImageCall.Source = ImageSource.FromFile(exersice);
            MyInstructionsItemShow.Text = Instructions;



        }
    }
}
