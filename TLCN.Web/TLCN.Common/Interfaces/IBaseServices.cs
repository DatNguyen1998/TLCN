using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TLCN.Common.Interfaces
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
