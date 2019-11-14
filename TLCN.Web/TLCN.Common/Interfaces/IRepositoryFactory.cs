using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.Common.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class, IEntity, new();
        IRepository<T> GetRepository<T>(bool forceAllItems) where T : class, IEntity, new();
    }
}
