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
    public class workoutRepository : IWorkoutRepository<Workout>
    {
        private const string BaseUrl = "https://workout-8655b-default-rtdb.firebaseio.com/";
        private readonly ChildQuery _query;

        public workoutRepository()
        {
            string path = "workout";
            _query = new FirebaseClient(BaseUrl).Child(path);
        }
        public async Task<Workout> GetNameAndDetailsAsync(string id)
        {
            try
            {
                var item = await _query
                    .Child(id)
                    .OnceSingleAsync<Workout>();
                item.Id = id;
                return item;
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
                var firebaseObjects = await _query.OnceAsync<Workout>();

                IEnumerable<Workout> test =  firebaseObjects
                    .Select(x => new Workout { Id = x.Key, Name = x.Object.Name, Detail = x.Object.Detail});
                return test;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
