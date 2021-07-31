using ETrafficViolationSystem.Data.Context;
using ETrafficViolationSystem.Data.Repository.Implementation;
using ETrafficViolationSystem.Data.Repository.Interface;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrafficViolationSystem.Data.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ETrafficViolationSystemContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ETrafficViolationSystemContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public ETrafficViolationSystemContext Context => _context;

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            IRepository<TEntity> repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> Commit()
        {
            try
            {
                int result;
                TransactionScope transactionScope;
                using (transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    result = await _context.SaveChangesAsync();
                    transactionScope.Complete();
                }
                transactionScope.Dispose();
                return result;
            }
            catch (Exception exception)
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        #region IDisposable Support
        // To detect redundant calls
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}