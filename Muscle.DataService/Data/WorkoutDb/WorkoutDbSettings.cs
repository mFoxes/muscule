using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.Data.WorkoutDb
{
    public class WorkoutDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string WorkoutsCollectionName { get; set; } = null!;
    }
}
