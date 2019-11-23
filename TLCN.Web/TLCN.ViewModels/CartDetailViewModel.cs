using System;
using System.ComponentModel.DataAnnotations;

namespace TLCN.ViewModels
{
    public class CartDetailViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public Guid CartId { get; set; }   //giỏ hàng của khách 
        public Guid ProductId { get; set; }    // Sản phẩm
        public int Amount { get; set; } //số lượng
    }
}
