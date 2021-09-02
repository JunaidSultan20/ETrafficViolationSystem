using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Data.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> Count { get; }

        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> GetWithPagination(Expression<Func<TEntity, bool>> expression, int pageNumber, int pageLimit);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}
