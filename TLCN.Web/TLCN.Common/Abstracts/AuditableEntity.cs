using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TLCN.Common
{
    public abstract class AuditableEntity: IAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [StringLength(255)]
        public string ModifiedBy { get; set; }
        [StringLength(255)]
        public string  AppService { get; set; }
        public bool IsActivated { get; set; }
    }
}
