using ERP.Application.Interfaces;
using ERP.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Implementation
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.TryGetValue(type, out var repository))
            {
                repository = new Repository<T>(_context);
                _repositories[type] = repository;
            }

            return (IRepository<T>)repository;
        }

        public async Task<int> SaveChangesAsync()
           {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await RollbackTransactionAsync();
                throw new InvalidOperationException("An error occurred while saving changes to the database.", ex);
            }
        }


        /// <summary>
        /// Begins a new database transaction asynchronously.
        /// </summary>
        public async Task BeginTransactionAsync()
        {
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Commits the current transaction asynchronously.
        /// </summary>
        public async Task CommitTransactionAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        /// <summary>
        /// Rolls back the current transaction asynchronously.
        /// </summary>
        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while rolling back the transaction.", ex);
            }
        }

        /// <summary>
        /// Disposes the context and transaction.
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
