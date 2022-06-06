using Muscle.DataService.Data;
using Muscle.DataService.IRepository.IRepositoryEquipmentDbContext;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.EquipmentRepository
{
    public class HallRepository : GenericRepository<Hall>, IHallRepository
    {
        public HallRepository(EquipmentDbContext context)
            : base(context)
        {

        }
    }
}
