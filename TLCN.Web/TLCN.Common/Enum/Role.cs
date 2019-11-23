using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TLCN.Common.Enum
{
    public enum Role
    {
        [Display(Name = "Administrator")]
        Administrator = 1,
        [Display(Name = "Member")]
        Member = 2,
    }
}
