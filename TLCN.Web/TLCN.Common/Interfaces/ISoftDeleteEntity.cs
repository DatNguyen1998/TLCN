using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.Common.Interfaces
{
    public interface ISoftDeleteEntity: IEntity
    {
        bool IsDeleted { get; set; }
    }
}
