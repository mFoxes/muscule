using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForUserDb
{
    public class SubscriptionUser
    {
        public int VisitCount { get; set; }

        [Required]
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
