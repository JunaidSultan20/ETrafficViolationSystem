using ETrafficViolationSystem.Data.Context;
using ETrafficViolationSystem.Data.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace ETrafficViolationSystem.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ETrafficViolationSystemContext Context { get; }

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Commit();
    }
}