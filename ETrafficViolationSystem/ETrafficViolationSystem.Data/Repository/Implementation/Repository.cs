using ETrafficViolationSystem.Data.Context;
using ETrafficViolationSystem.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Data.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ETrafficViolationSystemContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ETrafficViolationSystemContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Task<int> Count => _dbSet.CountAsync();

        public async Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbSet;
            return await (Task<IQueryable<TEntity>>)_dbSet.Where(predicate);
        }

        public async Task<TEntity> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            await Task.Run(() => _dbSet.Attach(entity));
        }

        public async Task<bool> Delete(object id)
        {
            TEntity entity = _dbSet.Find(id);
            if (entity != null)
            {
                await Task.Run(() => _dbSet.Remove(entity));
                return true;
            }
            return false;
        }
    }
}