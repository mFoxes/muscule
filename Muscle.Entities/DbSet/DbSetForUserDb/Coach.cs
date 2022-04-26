using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForUserDb
{
    [Table("Coach")]
    public class Coach : User
    {
        public string Description { get; set; }
        public int DirectionId { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
