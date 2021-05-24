using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository
{
    public interface IWorkoutRepository<T>
    {
        Task<T> GetNameAndDetailsAsync(string id);
        Task<IEnumerable<T>> GetWorkoutsAync(bool forceRefresh = false);
    }
}
