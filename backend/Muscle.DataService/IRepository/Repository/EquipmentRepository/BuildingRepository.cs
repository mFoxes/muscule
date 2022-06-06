using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Muscle.DataService.Data;
using Muscle.DataService.IRepository.IRepositoryEquipmentDbContext;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using Muscle.Entities.DbSet.Dtos.DtosForEquipmentDb.Outcoming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.EquipmentRepository
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(EquipmentDbContext context) 
            : base(context)
        {

        }

        public async Task<IEnumerable<Building>> GetAllWithHallAndEquipment()
        {
            var res = await _dbSet.Include(x => x.Halls)
                .ThenInclude(x => x.EquipmentHalls)
                .ThenInclude(x => x.Equipment)
                .ToListAsync();

            return res;
        }
    }
}
