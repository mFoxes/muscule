using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForEquipmentDb
{
    public class EquipmentHall : BaseEntity
    {
        public int Quantity { get; set; }

        public int? EquipmentId { get; set; }
        [JsonIgnore]
        public virtual Equipment Equipment { get; set; }

        public int? HallId { get; set; }
        [JsonIgnore]
        public Hall Hall { get; set; }
    }
}
