using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.Common
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        string AppService { get; set; }
        DateTimeOffset Modified { get; set; }
    }
}
