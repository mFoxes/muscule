using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.Entities.DbSet.Dtos.DtosForWorkoutDb.Incoming
{
    public class WorkoutDto
    {
        public string Name { get; set; }
        public int CoachId { get; set; }
        public int DirectionId { get; set; }
        public int SubscriptionId { get; set; }
        public int HallId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
