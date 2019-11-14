using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TLCN.Services
{
    public interface IProductService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
