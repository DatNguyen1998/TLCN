using System;
using System.Collections.Generic;
using System.Text;
using TLCN.Common;
using System.ComponentModel.DataAnnotations;
using TLCN.Common.Abstracts;

namespace TLCN.Models
{
    public class Bill: AuditableEntity
    {
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public double Total { get; set; }  //  tổng hóa đơn
        public Guid? PromotionId { get; set; }  // mã khuyến mãi 
        public string Status { get; set; }

        public virtual AuthUser AuthUser { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<DetailBill> DetailBills { get; set; }
    }
}
