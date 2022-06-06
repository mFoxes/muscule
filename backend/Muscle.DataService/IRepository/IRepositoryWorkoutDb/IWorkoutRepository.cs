using Muscle.Entities.DbSet.DbSetForWorkoutDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.IRepositoryWorkoutDb
{
    public interface IWorkoutRepository
    {
        // Create
        Task<string> Create(Workout workout);

        // Read
        Task<Workout> Get(string workoutId);
        Task<IEnumerable<Workout>> Get();
        Task<IEnumerable<Workout>> GetWorkoutsBySubscriptionsIds(IEnumerable<int> subscriptionsIds);
        Task<IEnumerable<Workout>> GetCurrentByCoachId(int coachId);
        Task<IEnumerable<Workout>> GetByCoachId(int coachId);
        // Update
        Task<bool> Update(string workoutId, Workout workout);

        // Delete
        Task<bool> Delete(string workoutId);
    }
}
