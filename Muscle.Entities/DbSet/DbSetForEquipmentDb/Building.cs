using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForEquipmentDb
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Direction> Directions { get; set; }
        public virtual ICollection<Hall> Halls { get; set; }
    }
}
