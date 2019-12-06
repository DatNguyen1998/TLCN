using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class DetailBill : AuditableEntity
    {
        public Guid ProductId { get; set; } // sản phẩm
        public Guid? BillId { get; set; }    // hóa đơn
        public int Amount { get; set; } // số lượng
        public double PriceTotal { get; set; } //giá = số lượng x giá của sản phẩm
        public Guid AuthUserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual AuthUser AuthUser { get; set; }
    }
}
