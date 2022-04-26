using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForEquipmentDb
{
    public class EquipmentHall
    {
        public int Quantity { get; set; }

        [Required]
        public int EquipmentId { get; set; }
        
        public virtual Equipment Equipment { get; set; }

        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
