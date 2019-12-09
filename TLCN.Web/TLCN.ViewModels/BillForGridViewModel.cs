using System;
using System.Collections.Generic;
using System.Text;

namespace TLCN.ViewModels
{
    public class BillForGridViewModel
    {
        public Guid Id { get; set; }
        public double Total { get; set; }  //  tổng hóa đơn
        public Guid? PromotionId { get; set; }  // mã khuyến mãi 
        public string PromotionCode { get; set; }  // mã khuyến mãi 
        public string PromotionName { get; set; }  // mã khuyến mãi 
        public string Status { get; set; }
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public string AuthUserFullName { get; set; }   // tài khoản khách hàng
        public string AuthUserCode { get; set; }   // tài khoản khách hàng
        public DateTimeOffset Created { get; set; }

    }
}
