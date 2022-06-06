using Microsoft.EntityFrameworkCore;
using Muscle.DataService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muscle.DataService.IRepository.Repository.UserRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        internal UserDbContext _context;
        internal DbSet<TEntity> _dbSet;
        public GenericRepository(UserDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var itemForRemove = await GetByIdAsync(id);
                if (itemForRemove != null)
                {
                    _dbSet.Remove(itemForRemove);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
