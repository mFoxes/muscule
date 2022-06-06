using Muscle.Entities.DbSet.DbSetForUserDb;
using Muscle.Entities.DbSet.DbSetForWorkoutDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.IRepositoryUserDbContext
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<SubscriptionUser>> GetSubscriptions(int userId);

        Task<User> LogIn(string Name, string password);

    }
}
