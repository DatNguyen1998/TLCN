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
        IEnumerable<TViewModel> GetAll();
        Task CreateAsync(TViewModel viewModel);

        Task<TViewModel> UpdateAsync(TViewModel viewModel, object id);

        Task DeleteAsync(object id);

        Task<TViewModel> FindByIdAsync(object id);

        Task<TViewModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
    }
}
