using MyApp.Models;
using MyApp.Repository;
using MyApp.Views;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class WorkoutPageViewModel : ViewModelBase, IPageLifecycleAware
    {
        private Workout selectedItem;
        private bool isBusy;

        private IWorkoutRepository<Workout> workoutRepository;
        public DelegateCommand LoadItemsCommand { get; }
        public ObservableCollection<Workout> WorkoutList { get; set; }

        public WorkoutPageViewModel(INavigationService navigationService, IFileHelper helper, IWorkoutRepository<Workout> workoutRepository)
            : base(navigationService)
        {
            Title = "Workout";
            WorkoutList = new ObservableCollection<Workout>();

            this.workoutRepository = workoutRepository;

            LoadItemsCommand = new DelegateCommand(async () => await ExecuteLoadItemsCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        public void OnDisappearing()
        {

        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private async Task ExecuteLoadItemsCommand()
        {
            //IsBusy = true;
            try
            {
                WorkoutList.Clear();
                var workouts = await workoutRepository.GetWorkoutsAync(true);
                foreach(var workout in workouts)
                {
                    WorkoutList.Add(workout);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Workout SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnItemSelected(Workout workout)
        {
            //var details = workout.Item as Workout;
            //await Navigation.PushAsync(new WorkoutDetailPage(details.Name, details.Image, details.ImageDetail, details.Instructions));

            if (workout == null)
                return;

            var p = new NavigationParameters();
            p.Add("workout", workout);
            await NavigationService.NavigateAsync(nameof(WorkoutDetailPage),p);
        }
    }
}
