using MyApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyApp.ViewModels
{
    public class WorkoutPageViewModel : ViewModelBase
    {
        public ObservableCollection<Workout> WorkoutList { get; set; }
        public WorkoutPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Workout";

            WorkoutList = new ObservableCollection<Workout>();

            WorkoutList.Add(new Workout { Name = "Biceps", Image = "Resources/drawable/Bicep_Icon.png", Detail = "Bicep Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over triceps" });
            WorkoutList.Add(new Workout { Name = "Triceps", Image = "Resources/drawable/Tricep_Icon.png", Detail = "Tricep Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over triceps" });
            WorkoutList.Add(new Workout { Name = "Legs", Image = "Resources/drawable/Leg_Icon.png", Detail = "Leg Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over legs" });
            WorkoutList.Add(new Workout { Name = "Back", Image = "Resources/drawable/Back_Icon.png", Detail = "Back Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over back" });
            WorkoutList.Add(new Workout { Name = "Sixpack", Image = "Resources/drawable/Sixpack_Icon.png", Detail = "SixPack Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over SixPack" });
            WorkoutList.Add(new Workout { Name = "Chest", Image = "Resources/drawable/Chest_Icon.png", Detail = "Chest Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over Chest" });
            WorkoutList.Add(new Workout { Name = "Upper body", Image = "Resources/drawable/Upperbody_Icon.png", Detail = "Upper Body Workout", ImageDetail = "Resources/drawable/BicepCurl_Gif.gif", 
                Instructions = "Dit is onze instructie pagina over Upper Body" });
        }
    }
}
