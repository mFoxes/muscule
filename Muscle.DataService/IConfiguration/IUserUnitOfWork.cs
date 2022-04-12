using Muscle.DataService.IRepository;
using Muscle.DataService.IRepository.Repository.UserRepository;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IConfiguration
{
    public interface IUserUnitOfWork
    {
        GenericRepository<Coach> CoachRepository { get; }
        GenericRepository<Document> DocumentRepository { get; }
        GenericRepository<Role> RoleRepository { get; }
        GenericRepository<Subscription> SubscriptionRepository { get; }
        GenericRepository<SubscriptionUser> SubscriptionUserRepository { get; }
        GenericRepository<User> UserRepository { get; }

        Task Save();
    }
}
