using Muscle.DataService.IConfiguration;
using Muscle.DataService.IRepository.IRepositoryEquipmentDbContext;
using Muscle.DataService.IRepository.Repository.EquipmentRepository;
using Muscle.Entities.DbSet.DbSetForEquipmentDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.Data
{
    public class EquipmentUnitOfWork : IDisposable, IEquipmentUnitOfWork
    {
        private readonly EquipmentDbContext _context;
        
        private IBuildingRepository buildingRepository;
        private IDirectionRepository directionRepository;
        private IEquipmentRepository equipmentRepository;
        private IEquipmentHallRepository equipmentHallRepository;
        private IHallRepository hallRepository;

        public EquipmentUnitOfWork(EquipmentDbContext context)
        {
            _context = context;
        }

        public IBuildingRepository BuildingRepository
        {
            get
            {
                if(buildingRepository == null)
                    buildingRepository = new BuildingRepository(_context);
                return buildingRepository;
            }
        }

        public IDirectionRepository DirectionRepository
        {
            get
            {
                if (directionRepository == null)
                    directionRepository = new DirectionRepository(_context);
                return directionRepository;
            }
        }

        public IEquipmentRepository EquipmentRepository
        {
            get
            {
                if(equipmentRepository == null)
                    equipmentRepository = new EquipmentRepository(_context);
                return equipmentRepository;
            }
        }

        public IEquipmentHallRepository EquipmentHallRepository
        {
            get
            {
                if(equipmentHallRepository == null)
                    equipmentHallRepository = new EquipmentHallRepository(_context);
                return equipmentHallRepository;
            }
        }

        public IHallRepository HallRepository
        {
            get
            {
                if(hallRepository == null)
                    hallRepository = new HallRepository(_context);
                return hallRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
