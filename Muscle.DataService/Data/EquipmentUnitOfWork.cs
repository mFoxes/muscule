using Muscle.DataService.IConfiguration;
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
        private GenericRepository<Building> buildingRepository;
        private GenericRepository<Direction> directionRepository;
        private GenericRepository<Equipment> equipmentRepository;
        private GenericRepository<EquipmentHall> equipmentHallRepository;
        private GenericRepository<Hall> hallRepository;

        public EquipmentUnitOfWork(EquipmentDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Building> BuildingRepository
        {
            get
            {
                if(buildingRepository == null)
                    buildingRepository = new GenericRepository<Building>(_context);
                return buildingRepository;
            }
        }

        public GenericRepository<Direction> DirectionRepository
        {
            get
            {
                if (directionRepository == null)
                    directionRepository = new GenericRepository<Direction>(_context);
                return directionRepository;
            }
        }

        public GenericRepository<Equipment> EquipmentRepository
        {
            get
            {
                if(equipmentRepository == null)
                    equipmentRepository = new GenericRepository<Equipment>(_context);
                return equipmentRepository;
            }
        }

        public GenericRepository<EquipmentHall> EquipmentHallRepository
        {
            get
            {
                if(equipmentHallRepository == null)
                    equipmentHallRepository = new GenericRepository<EquipmentHall>(_context);
                return equipmentHallRepository;
            }
        }

        public GenericRepository<Hall> HallRepository
        {
            get
            {
                if(hallRepository == null)
                    hallRepository = new GenericRepository<Hall>(_context);
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
