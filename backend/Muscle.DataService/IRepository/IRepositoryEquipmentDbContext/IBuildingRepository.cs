using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.IRepositoryEquipmentDbContext
{
    public interface IBuildingRepository : IGenericRepository<Building>
    {
        Task<IEnumerable<Building>> GetAllWithHallAndEquipment();
    }
}
