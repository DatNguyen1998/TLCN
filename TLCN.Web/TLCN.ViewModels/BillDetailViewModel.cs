using System;
using System.ComponentModel.DataAnnotations;
namespace TLCN.ViewModels
{
    public class BillDetailViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } // sản phẩm
        public int Amount { get; set; } // số lượng
        public double PriceTotal { get; set; } //giá = số lượng x giá của sản phẩm
        public Guid AuthUserId { get; set; }
        public bool IsActivated { get; set; }
    }
}
