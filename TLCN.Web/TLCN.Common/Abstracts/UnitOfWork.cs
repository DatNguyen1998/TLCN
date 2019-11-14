using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TLCN.Common.Interfaces;
namespace TLCN.Common.Abstracts
{
    public class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
    {
        private Dictionary<Type, object> _repositories;
        protected readonly IActionContextAccessor _ctxAccessor;

        public UnitOfWork(TContext context, IActionContextAccessor ctxAccessor)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _ctxAccessor = ctxAccessor;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new()
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context, _ctxAccessor, false);
            return (IRepository<TEntity>)_repositories[type];
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool forceAllItems) where TEntity : class, IEntity, new()
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context, _ctxAccessor, forceAllItems);
            return (IRepository<TEntity>)_repositories[type];
        }

        protected TContext Context { get; }

        TContext IUnitOfWork<TContext>.Context => throw new NotImplementedException();

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
