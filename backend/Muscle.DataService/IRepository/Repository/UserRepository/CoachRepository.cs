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
    public class CoachRepository : GenericRepository<Coach>, ICoachRepository
    {
        public CoachRepository(UserDbContext context)
            : base(context)
        {

        }
    }
}
