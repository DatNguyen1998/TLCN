using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;

namespace TLCN.Models
{
    public class Bill:AuditableEntity
    {
        [StringLength(50)]
        public string Code { get; set; }
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public double Total { get; set; }  //  tổng hóa đơn

        public virtual AuthUser AuthUser { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<DetailBill> DetailBills { get; set; }
    }
}
