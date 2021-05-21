﻿using MyApp.Models;
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
        //private string imageDetail;
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
        //public string ImageDetail
        //{
        //    get { return imageDetail; }
        //    set { SetProperty(ref imageDetail, value); }
        //}

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("workout"))
            {
                workout = parameters.GetValue<Workout>("workout");
                //ImageDetail = workout.ImageDetail;
                Detail = workout.Detail;
                Instructions = workout.Instructions;
            }
        }
    }
}
