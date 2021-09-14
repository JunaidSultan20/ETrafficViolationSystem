using ETrafficViolationSystem.Data.Context;
using ETrafficViolationSystem.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ETrafficViolationSystem.Common.Enumerators;

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

        public Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> expression)
        {
            return Task.Run(() => _dbSet.Where(expression).AsNoTracking().AsQueryable());
        }

        public Task<IQueryable<TEntity>> GetWithPagination(Expression<Func<TEntity, bool>> expression, int pageNumber,
            int pageLimit, string sortBy = null, SortingOrder? order = null)
        {
            return Task.Run(() => _dbSet.Where(expression).Skip((pageNumber - 1) * pageLimit).Take(pageLimit));
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Update(TEntity entity)
        {
            return Task.Run(() => _dbSet.Attach(entity));
        }

        public Task Delete(TEntity entity)
        {
            return Task.Run(() => _dbSet.Remove(entity));
        }
    }
}