using MyApp.ViewModels;
using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class BMICalculator : ContentPage
    {
        public BMICalculator()
        {
            InitializeComponent();
            BindingContext = new BMICalculatorViewModel();
        }

    }
}
