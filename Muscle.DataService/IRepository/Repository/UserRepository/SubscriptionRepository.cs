using Microsoft.EntityFrameworkCore;
using Muscle.DataService.Data;
using Muscle.DataService.IRepository.IRepositoryUserDbContext;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.UserRepository
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        public SubscriptionRepository(UserDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<SubscriptionUser>> GetUsers(int subscriptionId)
        {
            var res = await _dbSet.Include(x => x.SubscriptionsUser)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == subscriptionId);

            return res.SubscriptionsUser;
        }
    }
}
