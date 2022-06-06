using Muscle.DataService.IRepository.IRepositoryEquipmentDbContext;
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
        IBuildingRepository BuildingRepository { get; }
        IDirectionRepository DirectionRepository { get; }
        IEquipmentRepository EquipmentRepository { get; }
        IEquipmentHallRepository EquipmentHallRepository { get; }
        IHallRepository HallRepository { get; }
        
        Task Save();
    }
}
