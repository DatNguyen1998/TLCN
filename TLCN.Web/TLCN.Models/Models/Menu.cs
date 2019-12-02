using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class Menu: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        public virtual Menu Parent { get; set; }
    }
}
