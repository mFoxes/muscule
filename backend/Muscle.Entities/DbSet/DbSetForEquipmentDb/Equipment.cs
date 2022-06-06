using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForEquipmentDb
{
    public class Equipment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty(nameof(EquipmentHall.Equipment))]
        public virtual ICollection<EquipmentHall> EquipmentHalls { get; set; }
    }
}
