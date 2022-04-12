using Muscle.DataService.IRepository.Repository.EquipmentRepository;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IConfiguration
{
    public interface IEquipmentUnitOfWork
    {
        GenericRepository<Building> BuildingRepository { get; }
        GenericRepository<Direction> DirectionRepository { get; }
        GenericRepository<Equipment> EquipmentRepository { get; }
        GenericRepository<EquipmentHall> EquipmentHallRepository { get; }
        GenericRepository<Hall> HallRepository { get; }

        Task Save();
    }
}
