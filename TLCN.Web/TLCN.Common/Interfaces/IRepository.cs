using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TLCN.Common.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll(String order = "", params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll(string order, int pageIndex, int limit, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllAsync(string order = "", params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllAsync(string order, int pageIndex, int limit, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> order, int pageIndex, int limit, params Expression<Func<T, object>>[] includeProperties);
        T FindById(Guid id, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(Expression<Func<T, bool>> predicate, string order = "", params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, string order = "", params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, string order = "", params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(string order, int pageIndex, int limit, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<H> GetAll<H>(string order = "");
        IEnumerable<H> GetAll<H>(string order, int pageIndex, int limit);
        Task<IEnumerable<H>> GetAllAsync<H>(string order = "");
        Task<IEnumerable<H>> GetAllAsync<H>(string order, int pageIndex, int limit);
        Task<IEnumerable<H>> GetAllAsync<H, TKey>(Expression<Func<T, TKey>> order, int pageIndex, int limit);
        H FindById<H>(Guid id);
        Task<H> FindByIdAsync<H>(Guid id);
        H GetSingle<H>(Expression<Func<T, bool>> predicate, string order = "");
        Task<H> GetSingleAsync<H>(Expression<Func<T, bool>> predicate, string order = "");
        IEnumerable<H> FindBy<H>(Expression<Func<T, bool>> predicate, string order = "");
        IEnumerable<H> FindBy<H>(string order, int pageIndex, int limit, Expression<Func<T, bool>> predicate);
        Task<IEnumerable<H>> FindByAsync<H>(Expression<Func<T, bool>> predicate, string order = "");
        Task<IEnumerable<H>> FindByAsync<H>(string order, int pageIndex, int limit, Expression<Func<T, bool>> predicate);
        Task<IEnumerable<H>> FindByAsync<H, Tkey>(Expression<Func<T, Tkey>> order, int pageIndex, int limit, Expression<Func<T, bool>> predicate);
        IEnumerable<H> FindBy<H>(string predicate, object[] parameters, string order = "");
        IEnumerable<H> FindBy<H>(string order, int pageIndex, int limit, string predicate, object[] parameters);
        Task<IEnumerable<H>> FindByAsync<H>(string predicate, object[] parameters, string order = "");
        Task<IEnumerable<H>> FindByAsync<H>(string order, int pageIndex, int limit, string predicate, object[] parameters);

        int CountAll();
        Task<int> CountAllAsync();
        int Count(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Detach(T entity);
        void Detach(IEnumerable<T> entities);
        void Delete(T entity);
        void Update(T entity);
        void Add(IEnumerable<T> entities);
        void AddNoIdentity(IEnumerable<T> entites);
        void Delete(IEnumerable<T> entites);
        void Update(IEnumerable<T> entities);
    }
}
