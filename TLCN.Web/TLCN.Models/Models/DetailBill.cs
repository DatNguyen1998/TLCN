using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;

namespace TLCN.Models
{
    public class DetailBill: AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public Guid BillId { get; set; }    // hóa đơn
        public int Amount { get; set; } // số lượng
        public double PriceTotal { get; set; } //giá = số lượng x giá của sản phẩm

        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
