using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.Dtos.DtosForUserDb.Incoming
{
    public class SubscriptionDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
