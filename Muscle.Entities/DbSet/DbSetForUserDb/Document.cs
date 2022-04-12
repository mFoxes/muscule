using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.DbSetForUserDb
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Descr { get; set; }

        public int? CoachId { get; set; }
        [JsonIgnore]
        public Coach Coach { get; set; }
    }
}
