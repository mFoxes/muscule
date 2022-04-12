using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForEquipmentDb
{
    public class Direction : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int? BuildingId { get; set; }
        [JsonIgnore]
        public Building Building { get; set; }

        public virtual ICollection<Hall> Halls { get; set; }
    }
}
