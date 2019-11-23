using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TLCN.Common;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class Cart: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid AuthUserId { get; set; }   //khách hàng

        public virtual AuthUser AuthUser { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
