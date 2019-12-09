using System;
using System.ComponentModel.DataAnnotations;
namespace TLCN.ViewModels
{
    public class BillViewModel
    {
        public Guid Id { get; set; }
        public Guid AuthUserId { get; set; }   // tài khoản khách hàng
        public double Total { get; set; }  //  tổng hóa đơn
        public string Status { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
