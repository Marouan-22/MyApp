using Firebase.Database;
using Firebase.Database.Query;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public class WorkoutRepository : IWorkoutRepository<Workout>
    {
        private const string BaseUrl = "https://workout-8655b-default-rtdb.firebaseio.com/";
        private readonly ChildQuery _query;

        public WorkoutRepository()
        {
            string path = "workout";
            _query = new FirebaseClient(BaseUrl).Child(path);/*.Child("Id")*/
        }
        public async Task<Workout> GetNameAndDetailsAsync(string id)
        {
            try
            {
                var workout = await _query
                    .Child(id)
                    .OnceSingleAsync<Workout>();
                workout.Id = id;
                return workout;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsAync(bool forceRefresh = false)
        {
            try
            {
                //var firebaseObjects = await _query.OnceAsync<Workout>();

                ///*IEnumerable<Workout> test =*/ return firebaseObjects
                //    .Select(x => new Workout { Id = x.Key, Name = x.Object.Name, Detail = x.Object.Detail});
                ////return test;

                var firebaseObjects = await _query.OnceAsync<Workout>();
                return firebaseObjects.Select(x => new Workout
                {
                    Id = x.Key,
                    Name = x.Object.Name,
                    Detail = x.Object.Detail,
                    Instructions = x.Object.Instructions,
                    Sets = x.Object.Sets,
                    Reps = x.Object.Reps,
                    Rest = x.Object.Rest
                });
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
