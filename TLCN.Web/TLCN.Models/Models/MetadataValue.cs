using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class MetadataValue: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        public Guid? TypeId { get; set; }
        public Guid? ParentId { get; set; }

        public virtual MetadataType Type { get; set; }
        public virtual MetadataValue Parent { get; set; }

    }
}
