using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForUserDb
{
    public class SubscriptionUser : BaseEntity
    {
        public DateTime StartData { get; set; }

        public int SubscriptionId { get; set; }
        [JsonIgnore]
        public Subscription Subscription { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
