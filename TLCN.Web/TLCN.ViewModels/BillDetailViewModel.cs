using System;
using System.ComponentModel.DataAnnotations;
namespace TLCN.ViewModels
{
    public class BillDetailViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public Guid BillId { get; set; }    // hóa đơn
        public int Amount { get; set; } // số lượng
        public double PriceTotal { get; set; } //giá = số lượng x giá của sản phẩm
    }
}
