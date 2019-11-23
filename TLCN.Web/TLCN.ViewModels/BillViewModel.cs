using System;
using System.ComponentModel.DataAnnotations;
namespace TLCN.ViewModels
{
    public class BillViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public double Total { get; set; }  //  tổng hóa đơn
    }
}
