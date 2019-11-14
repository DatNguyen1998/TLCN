using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.Common.Interfaces
{
    public interface IOwnerOnly
    {
        string CreatedBy { get; set; }
    }
}
