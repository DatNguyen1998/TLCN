
using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.Common.Abstracts
{

    public abstract class AuditableEntity :  IAuditableEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; }
        [StringLength(255)]
        public string ModifiedBy { get; set; }
        [StringLength(255)]
        public string AppService { get; set; }
        public bool IsActivated { get; set; }
    }
}