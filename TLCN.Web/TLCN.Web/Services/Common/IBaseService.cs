using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TLCN.Web.Services
{
    public interface IBaseService<TEntity, TViewModel> 
        where TEntity : class
        where TViewModel : class
    {
        IEnumerable<TEntity> GetAll(string includes = "");
        Task CreateAsync(TViewModel viewModel);

        Task<TViewModel> UpdateAsync(TViewModel viewModel, object id);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(object id);

        Task<TViewModel> FindByIdAsync(object id);
        IEnumerable<TEntity> FindToEntity(Expression<Func<TEntity, bool>> filter = null, string includes = "");
        IEnumerable<TViewModel> FindToViewModel(Expression<Func<TEntity, bool>> filter = null, string includes = "");

        Task<TViewModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
    }
}
