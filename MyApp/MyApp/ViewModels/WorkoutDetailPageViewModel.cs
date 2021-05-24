using MyApp.Models;
using MyApp.Repository;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.ViewModels
{
    public class WorkoutDetailPageViewModel : ViewModelBase
    {
        private string detail;
        private string instructions;
        private string sets;
        private string reps;
        private string rest;
        private Workout workout;
        private IWorkoutRepository<Workout> workoutRepository;
        public WorkoutDetailPageViewModel(INavigationService navigationService, IWorkoutRepository<Workout> workoutRepository)
                        : base(navigationService)
        {

            Title = "Instruction";
            this.workoutRepository = workoutRepository;
        }
        public string Detail
        {
            get { return detail; }
            set { SetProperty(ref detail, value); }
        }

        public string Instructions
        {
            get { return instructions; }
            set { SetProperty(ref instructions, value); }
        }

        public string Sets
        {
            get { return sets; }
            set { SetProperty(ref sets, value); }
        }

        public string Reps
        {
            get { return reps; }
            set { SetProperty(ref reps, value); }
        }

        public string Rest
        {
            get { return rest; }
            set { SetProperty(ref rest, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("workout"))
            {
                workout = parameters.GetValue<Workout>("workout");
                Detail = workout.Detail;
                Instructions = workout.Instructions;
                Sets = workout.Sets;
                Reps = workout.Reps;
                Rest = workout.Rest;
            }
        }
    }
}
