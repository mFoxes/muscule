using Microsoft.EntityFrameworkCore;
using Muscle.DataService.Data;
using Muscle.DataService.IRepository.IRepositoryUserDbContext;
using Muscle.Entities.DbSet.DbSetForUserDb;
using Muscle.Entities.DbSet.DbSetForWorkoutDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<SubscriptionUser>> GetSubscriptions(int userId)
        {
            var res = await _dbSet.Include(x => x.SubscriptionUsers)
                .ThenInclude(x => x.Subscription)
                .FirstOrDefaultAsync(x => x.Id == userId);

            return res.SubscriptionUsers;
        }

        

        public async Task<User> LogIn(string Name, string password)
        {
            var res = await _dbSet.Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == Name && x.Password == password);

            return res;
        }


    }
}
