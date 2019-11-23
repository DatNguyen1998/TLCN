using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class CartDetail:AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid CartId { get; set; }   //giỏ hàng của khách 
        public Guid ProductId { get; set; }    // Sản phẩm
        public int Amount { get; set; } //số lượng

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
