using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForUserDb
{
    public class Subscription : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public virtual ICollection<SubscriptionUser> SubscriptionsUser { get; set; }
    }
}
