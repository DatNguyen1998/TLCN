using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class Promotion:AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public int DisCount { get; set; }   // số giảm giá
        public string Description { get; set; } // mô tả
    }
}
