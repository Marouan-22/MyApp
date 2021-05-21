using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public interface IWorkoutRepository<T>
    {
        Task<IEnumerable<T>> GetWorkoutsAync(bool forceRefresh = false);

        Task<T> GetNameAndDetailsAsync(string id);
        
        //Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
