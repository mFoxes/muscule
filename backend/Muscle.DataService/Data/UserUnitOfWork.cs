using Muscle.DataService.IConfiguration;
using Muscle.DataService.IRepository.IRepositoryUserDbContext;
using Muscle.DataService.IRepository.Repository.UserRepository;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.Data
{
    public class UserUnitOfWork : IDisposable, IUserUnitOfWork
    {
        private readonly UserDbContext _context;
        //private GenericRepository<Coach> coachRepository;
        //private GenericRepository<Document> documentRepository;
        //private GenericRepository<Role> roleRepository;
        //private GenericRepository<Subscription> subscriptionRepository;
        //private GenericRepository<SubscriptionUser> subscriptionUserRepository;
        //private GenericRepository<User> userRepository;

        private ICoachRepository coachRepository;
        private IDocumentRepository documentRepository;
        private IRoleRepository roleRepository;
        private ISubscriptionRepository subscriptionRepository;
        private ISubscriptionUserRepository subscriptionUserRepository;
        private IUserRepository userRepository;

        public UserUnitOfWork(UserDbContext context)
        {
            _context = context;
        }

        public ICoachRepository CoachRepository
        {
            get
            {
                if(coachRepository == null)
                    coachRepository = new CoachRepository(_context);
                return coachRepository;
            }
        }

        public IDocumentRepository DocumentRepository
        {
            get
            {
                if(documentRepository == null)
                    documentRepository = new DocumentRepository(_context);
                return documentRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if(roleRepository == null)
                    roleRepository = new RoleRepository(_context);
                return roleRepository;
            }
        }

        public ISubscriptionRepository SubscriptionRepository
        {
            get
            {
                if(subscriptionRepository == null)
                    subscriptionRepository = new SubscriptionRepository(_context);
                return subscriptionRepository;
            }
        }

        public ISubscriptionUserRepository SubscriptionUserRepository
        {
            get
            {
                if (subscriptionRepository == null)
                    subscriptionUserRepository = new SubscriptionUserRepository(_context);
                return subscriptionUserRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if(userRepository == null)
                    userRepository = new UserRepository(_context);
                return userRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if(disposing)
                { 
                    _context.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
