using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.Dtos.DtosForEquipmentDb.Incoming
{
    public class EquipmentHallDto
    {
        public int Quantity { get; set; }
        public int EquipmentId { get; set; }
        public int HallId { get; set; }
    }
}
