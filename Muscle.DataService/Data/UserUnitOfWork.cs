using Muscle.DataService.IConfiguration;
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
        private GenericRepository<Coach> coachRepository;
        private GenericRepository<Document> documentRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<Subscription> subscriptionRepository;
        private GenericRepository<SubscriptionUser> subscriptionUserRepository;
        private GenericRepository<User> userRepository;

        public UserUnitOfWork(UserDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Coach> CoachRepository
        {
            get
            {
                if(coachRepository == null)
                    coachRepository = new GenericRepository<Coach>(_context);
                return coachRepository;
            }
        }

        public GenericRepository<Document> DocumentRepository
        {
            get
            {
                if(documentRepository == null)
                    documentRepository = new GenericRepository<Document>(_context);
                return documentRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if(roleRepository == null)
                    roleRepository = new GenericRepository<Role>(_context);
                return roleRepository;
            }
        }

        public GenericRepository<Subscription> SubscriptionRepository
        {
            get
            {
                if(subscriptionRepository == null)
                    subscriptionRepository = new GenericRepository<Subscription>(_context);
                return subscriptionRepository;
            }
        }

        public GenericRepository<SubscriptionUser> SubscriptionUserRepository
        {
            get
            {
                if (subscriptionRepository == null)
                    subscriptionUserRepository = new GenericRepository<SubscriptionUser>(_context);
                return subscriptionUserRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if(userRepository == null)
                    userRepository = new GenericRepository<User>(_context);
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
