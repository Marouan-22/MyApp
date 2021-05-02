using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MyApp.ViewModels
{
    public class BMICalculatorViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public BMICalculatorViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "BMI";
        }


        private double height = 180;
        private double weight = 72;
        private const double STEP = 1.0;
        public double Height
        {
            get => height;
            set
            {
                height = NextStep(value);
                Update();
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                Update();
            }
        }
        public string Classification
        {
            get
            {
                if (Bmi < 18.5)
                {
                    return "You are underweight";
                }
                else if (Bmi < 25)
                {
                    return "You have a normal weight";
                }
                else if (Bmi < 30)
                {
                    return "You are overweight";
                }
                else
                {
                    return "You are obese";
                }
            }
        }

        public double Bmi
        {
            get
            {
                return Math.Round(Weight / Math.Pow(Height / 100, 2), 2);
            }
        }

        private void Update()
        {
            RaisePropertyChanged(nameof(Bmi));
            RaisePropertyChanged(nameof(Classification));
        }

        private double NextStep(double value) => Math.Round(value / STEP) * STEP;
        private void RaisePropertyChanged(string propertyName) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
