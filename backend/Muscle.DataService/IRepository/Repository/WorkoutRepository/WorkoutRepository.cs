using MongoDB.Driver;
using Muscle.DataService.IRepository.IRepositoryWorkoutDb;
using Muscle.Entities.DbSet.DbSetForWorkoutDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.WorkoutRepository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly IMongoCollection<Workout> _workouts;

        public WorkoutRepository(IMongoClient client)
        {
            var database = client.GetDatabase("WorkoutStore");
            var collection = database.GetCollection<Workout>("Workouts");

            _workouts = collection;
        }

        public async Task<string> Create(Workout workout)
        {
            await _workouts.InsertOneAsync(workout);
            return workout.Id;
        }

        public async Task<bool> Delete(string workoutId)
        {
            try
            {
                await _workouts.DeleteOneAsync(workoutId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<Workout> Get(string workoutId) =>
            await _workouts.Find(x => x.Id == workoutId).FirstOrDefaultAsync();

        public async Task<IEnumerable<Workout>> Get() =>
            await _workouts.Find(_ => true).ToListAsync();

        public async Task<IEnumerable<Workout>> GetCurrentByCoachId(int coachId) =>
            await _workouts.Find(x => x.CoachId == coachId && x.StartTime >= DateTime.Now).ToListAsync();

        public async Task<IEnumerable<Workout>> GetByCoachId(int coachId) =>    
            await _workouts.Find(x => x.CoachId == coachId).ToListAsync();

        public async Task<IEnumerable<Workout>> GetWorkoutsBySubscriptionsIds(IEnumerable<int> subscriptionsIds) =>
            await _workouts.Find(x => subscriptionsIds.Contains(x.SubscriptionId)).ToListAsync();
            
        

        public async Task<bool> Update(string workoutId, Workout workout)
        {
            try
            {
                await _workouts.ReplaceOneAsync(x => x.Id == workout.Id, workout);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
