using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.ModelBuilder;
using Muscle.Entities.DbSet.DbSetForUserDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.Data
{
    public class UserDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubscriptionUser>()
                .HasKey(x => new { x.SubscriptionId, x.UserId });
        }

        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionUser> SubscriptionUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        
    }
}
