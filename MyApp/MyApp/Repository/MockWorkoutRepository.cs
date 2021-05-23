using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    
    public class MockWorkoutRepository : IWorkoutRepository<Workout>
    {
        private IFileHelper helper;
        private ObservableCollection<Workout> WorkoutList = new ObservableCollection<Workout>();
        
        public ObservableCollection<Workout> GetWorkouts()
        {
            WorkoutList.Add(new Workout
            {
                Name = "Biceps",
                //Image = "Resources/drawable/Bicep_Icon.png",
                Detail = "Bicep Workout",
                //ImageDetail = "Resources/drawable/BicepCurl_Gif.gif",
                //Instructions = helper.GetFileContent()
            });
            WorkoutList.Add(new Workout
            {
                Name = "Triceps",
                //Image = "Resources/drawable/Tricep_Icon.png",
                Detail = "Tricep Workout",
                //ImageDetail = "Resources/drawable/Tricep_Icon.png",
                //Instructions = "Dit is onze instructie pagina over triceps"
            });
            WorkoutList.Add(new Workout
            {
                Name = "Legs",
                //Image = "Resources/drawable/Leg_Icon.png",
                Detail = "Leg Workout",
                //ImageDetail = "Resources/drawable/Leg_Icon.png",
                //Instructions = "Dit is onze instructie pagina over legs"
            });
            WorkoutList.Add(new Workout
            {
                Name = "Back",
                //Image = "Resources/drawable/Back_Icon.png",
                Detail = "Back Workout",
                //ImageDetail = "Resources/drawable/Back_Icon.png",
                //Instructions = "Dit is onze instructie pagina over back"
            });
            WorkoutList.Add(new Workout
            {
                Name = "Sixpack",
                //Image = "Resources/drawable/Sixpack_Icon.png",
                Detail = "SixPack Workout",
                //ImageDetail = "Resources/drawable/Sixpack_Icon.png",
                //Instructions = "Dit is onze instructie pagina over SixPack"
            });
            WorkoutList.Add(new Workout
            {
                Name = "Chest",
                //Image = "Resources/drawable/Chest_Icon.png",
                Detail = "Chest Workout",
                //ImageDetail = "esources/drawable/Chest_Icon.png",
                //Instructions = "Dit is onze instructie pagina over Chest"
            });
            WorkoutList.Add(new Workout
            {
                Name = "Upper body",
                //Image = "Resources/drawable/Upperbody_Icon.png",
                Detail = "Upper Body Workout",
                //ImageDetail = "Resources/drawable/Upperbody_Icon.png",
                //Instructions = "Dit is onze instructie pagina over Upper Body"
            });

            return WorkoutList;
        }

        public Task<IEnumerable<Workout>> GetWorkoutsAync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> GetNameAndDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> GetNameAndDetailsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public MockWorkoutRepository(IFileHelper fileHelper)
        {
            this.helper = fileHelper;
        }

    }
}
