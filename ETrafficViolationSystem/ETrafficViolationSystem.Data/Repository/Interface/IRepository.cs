using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Data.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> Count { get; }

        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> GetById(object id);

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task<bool> Delete(object id);
    }
}
