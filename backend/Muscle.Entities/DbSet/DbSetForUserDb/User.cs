using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForUserDb
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        
        public virtual ICollection<SubscriptionUser> SubscriptionUsers { get; set; }

    }
}
