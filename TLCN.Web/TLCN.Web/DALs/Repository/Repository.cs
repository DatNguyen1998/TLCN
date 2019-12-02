using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TLCN.Models;

namespace TLCN.Web.DALs
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal TLCNDatabaseContext _context;
        internal DbSet<TEntity> _db;

        public Repository(TLCNDatabaseContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(object id)
        {
            TEntity entity = _db.Find(id);
            _context.Entry(entity).State = EntityState.Deleted;
        }


        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _db.FindAsync(id);
            
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, string includes = "")
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includes.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();

        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, string includes = "")
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includes.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _db;

            foreach(Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}
